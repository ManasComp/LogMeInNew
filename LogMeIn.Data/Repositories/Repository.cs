using System.Linq.Expressions;
using LogMeIn.Data.Data;
using LogMeIn.Data.Repositories.IRepositories;
using LogMeIn.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LogMeIn.Data.Repositories;

public class Repository<T, TK> : IRepository<T, TK> where T : class, IBaseModel<TK>
    where TK : notnull, IComparable<TK>, IComparable
{
    protected readonly ApplicationDbContext Context;
    protected DbSet<T> DbSet;

    protected Repository(ApplicationDbContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }

    public void Update(T item)
    {
        DbSet.Update(item);
    }

    public IQueryable<T> GetAsQuery(Expression<Func<T, bool>>? filter = null, bool tracked = false)
    {
        IQueryable<T> query = DbSet;

        if (!tracked)
            query = DbSet.AsNoTracking();

        if (filter != null) query = query.Where(filter);

        return query;
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
        bool tracked = false)
    {
        var query = GetAsQuery(filter, tracked);

        if (string.IsNullOrEmpty(includeProperties)) return query.ToList();

        foreach (var includeProperty in includeProperties.Split(new[] { ',' },
                     StringSplitOptions.RemoveEmptyEntries))
            query = query.Include(includeProperty).AsNoTracking();

        return query.ToList();
    }


    public T? Get<TK, TU>(Expression<Func<T, bool>> filter, Expression<Func<T, TK>> outerProp,
        Expression<Func<TK, TU>>? innerProp = null, bool tracked = false)
    {
        var query = GetAsQuery(filter, tracked);

        if (innerProp == null)
            query = query.Include(outerProp).AsNoTracking();
        else
            query = query.Include(outerProp)
                .ThenInclude(innerProp).AsNoTracking();

        return query.FirstOrDefault();
    }


    public T? Get(Expression<Func<T, bool>> filter, bool tracked = false)
    {
        IQueryable<T> query = DbSet;

        if (!tracked)
            query = DbSet.AsNoTracking();

        if (filter != null) query = query.Where(filter);

        // if (string.IsNullOrEmpty(includeProperties)) return query.FirstOrDefault();
        //
        // foreach (var includeProperty in includeProperties.Split(new[] { ',' },
        //              StringSplitOptions.RemoveEmptyEntries))
        //     query = query.Include(includeProperty);

        return query.FirstOrDefault();
    }


    public IQueryable<T> GetQueryById(TK Id, bool tracked = false)
    {
        IQueryable<T> query = DbSet;

        if (!tracked)
            query = DbSet.AsNoTracking();

        if (Id != null) query = query.Where(x => x.Id.CompareTo(Id) == 0);

        return query;
    }

    public T GetById(TK id, bool tracked = false)
    {
        return GetQueryById(id, tracked).First() ??
               throw new InvalidOperationException($"Entity with id {id} not found");
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void AddAndSave(T entity)
    {
        Add(entity);
        Context.SaveChanges();
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        DbSet.RemoveRange(entity);
    }

    public T? Get<TK>(Expression<Func<T, bool>> filter, Expression<Func<T, TK>> prop, bool tracked = false)
    {
        var query = GetAsQuery(filter, tracked);
        query = query.Include(prop).AsNoTracking();

        return query.First();
    }

    public async Task<IEnumerable<T>> GetAllEntities()
    {
        return await Context.Set<T>()
            .ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllEntitiesWithPagination(int pageNumber = 1, int pageSize = 10)
    {
        return await Context.Set<T>()
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<T> GetEntityById(int entityId)
    {
        return await Context.Set<T>()
            .FindAsync(entityId) ?? throw new Exception($"Entity with id {entityId} not found");
    }

    public async Task<int> GetNumberOfEntities()
    {
        return await Context.Set<T>()
            .CountAsync();
    }

    public async Task CreateEntity(T entity)
    {
        await Context.Set<T>()
            .AddAsync(entity);
    }

    public async Task DeleteEntity(int entityId)
    {
        var entity = await Context.Set<T>().FindAsync(entityId);

        if (entity != null)
            Context.Set<T>()
                .Remove(entity);
    }

    public void UpdateEntity(T entity)
    {
        Context.Set<T>()
            .Update(entity);
    }

    public T? Get(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> outerProp, bool tracked = false)
    {
        var query = GetAsQuery(filter, tracked);
        foreach (var expression in outerProp) query = query.Include(expression).AsNoTracking();

        return query.FirstOrDefault();
    }

    public T? Get(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> outerProp,
        List<Expression<Func<object, object>>> innerProp, bool tracked = false)
    {
        var query = GetAsQuery(filter, tracked);
        foreach (var expression in outerProp) query = query.Include(expression).AsNoTracking();

        return query.FirstOrDefault();
    }
}