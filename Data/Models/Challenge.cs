using Data.Interface;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;
public partial class Challenge: IEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public int TotalDays { get; set; }

    public int TotalWeeks { get; set; }

    public bool Deleted { get; set; }

    public DateTime CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
}
