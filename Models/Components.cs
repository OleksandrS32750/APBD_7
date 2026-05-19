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

    public int ComponentTypesId { get; set; }
    public ComponentType ComponentType { get; set; } = null!;

}