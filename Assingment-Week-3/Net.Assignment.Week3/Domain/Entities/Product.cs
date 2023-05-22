using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

[Table("Products", Schema = "dbo")]
public class Product : BaseEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Tag { get; set; }
    public virtual Category Category { get; set; }
}