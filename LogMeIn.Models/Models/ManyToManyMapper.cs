using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LogMeIn.Models.Models;

public class ManyToManyMapper<T> : BaseModel
{
    public ManyToManyMapper(int id, int attributeId, string groupId)
    {
        AttributeId = attributeId;
        GroupId = groupId;
        Id = id;
    }

    public ManyToManyMapper(int attributeId, string groupId)
    {
        AttributeId = attributeId;
        GroupId = groupId;
    }

    public ManyToManyMapper()
    {
    }

    /**
     * FOreign key to Group
     */
    [Required(ErrorMessage = "Tento atribut je povinný")]
    public string GroupId { get; set; }

    [ValidateNever]
    [ForeignKey(nameof(AttributeId))]
    public virtual T Attribute { get; set; }

    [Required(ErrorMessage = "Tento atribut je povinný")]
    public int AttributeId { get; set; }
}