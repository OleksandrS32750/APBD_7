using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_7.Models;

public class PC
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "float(5)")]
    public double Weight { get; set; }

    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int Stock { get; set; }

    public IEnumerable<PCComponent> PCComponents { get; set; } = [];
}