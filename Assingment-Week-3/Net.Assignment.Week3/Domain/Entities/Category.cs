using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

[Table("Categories", Schema = "dbo")]
public class Category : BaseEntity
{
    public string Name { get; set; }
    public int Order { get; set; }
    public virtual List<Product> Products { get; set; }
}