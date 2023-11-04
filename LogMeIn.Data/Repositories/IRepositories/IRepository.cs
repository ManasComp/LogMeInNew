using System.Linq.Expressions;

namespace LogMeIn.Data.Repositories.IRepositories;

public interface IRepository<T, TK> where T : class
{
    void Update(T item);
    IQueryable<T> GetAsQuery(Expression<Func<T, bool>>? filter = null, bool tracked = false);

    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
        bool tracked = false);

    T? Get<TK, TU>(Expression<Func<T, bool>> filter, Expression<Func<T, TK>> outerProp,
        Expression<Func<TK, TU>>? innerProp = null, bool tracked = false);

    T? Get(Expression<Func<T, bool>> filter, bool tracked = false);
    void Add(T entity);
    void AddAndSave(T entity);
    void Remove(T entity);
    public IQueryable<T> GetQueryById(TK Id, bool tracked = false);
    public T GetById(TK Id, bool tracked = false);
    void RemoveRange(IEnumerable<T> entity);
    T? Get<TK>(Expression<Func<T, bool>> filter, Expression<Func<T, TK>> prop, bool tracked = false);
    Task<IEnumerable<T>> GetAllEntities();
    Task<IEnumerable<T>> GetAllEntitiesWithPagination(int pageNumber = 1, int pageSize = 10);
    Task<T> GetEntityById(int entityId);
    Task<int> GetNumberOfEntities();
    Task CreateEntity(T entity);
    Task DeleteEntity(int entityId);
    void UpdateEntity(T entity);
    T? Get(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> outerProp, bool tracked = false);

    T? Get(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> outerProp,
        List<Expression<Func<object, object>>> innerProp, bool tracked = false);
}