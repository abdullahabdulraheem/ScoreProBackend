

using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Competition
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompetitionName { get; set; } = default!;
        public string CompetitionType { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? CompetitionImageUrl { get; set; } = default!;
        public string CreatedByUserId { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = CompetitionStatus.NotStarted.ToString();
        public bool Transparency { get; set; }
        public User CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public List<Judge> AssignedJudges { get; set; } = default!;
        public List<Contestant> Contestants { get; set; } = default!;
        public List<ScoringCriterion> ScoringCriteria { get; set; } = default!;
        public List<Team> Teams { get; set; } = default!;
    }
}