using System.ComponentModel.DataAnnotations;

namespace Task_7.Models;

public class ComponentType
{
    [Key]
    public int Id { get; set; }

    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;

    public string Name { get; set; } = null!;

    public IEnumerable<Component> Components { get; set; } = [];
}