using System.ComponentModel.DataAnnotations;

namespace Task_7.Models;

public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }

    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;

    [MaxLength(300)]
    public string FullName { get; set; } = null!;

    public DateOnly FoundationDate { get; set; }

    public IEnumerable<Component> Components { get; set; } = [];
}