using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_7.Models;

public class Component
{
    [Key]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = null!;

    [MaxLength(300)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = null!;

    public int ComponentManufacturersId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<PCComponent> PCComponents { get; set; } = [];

}