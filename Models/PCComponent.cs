using System.ComponentModel.DataAnnotations;

namespace Task_7.Models;

public class PCComponent
{
    [Key]
    public int PCId { get; set; }

    [MaxLength(10)]
    public string ComponentCode { get; set; } = null!;

    public int Amount { get; set; }
}