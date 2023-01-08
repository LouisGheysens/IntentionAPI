using DTO.Interface;

namespace DTO.Models;
public class ChallengeDto : IDto
{
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
