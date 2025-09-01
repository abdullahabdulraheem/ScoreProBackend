

namespace Domain.Entities
{
    public class Team
    {
        public string Id = Guid.NewGuid().ToString();
        public string TeamName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? TeamLogoUrl { get; set; } = default!;
        public string CompetitionId { get; set; } = default!;
        public string CreatedByUserId { get; set; } = default!;
        public int AverageScore { get; set; }
        public int TotalScore { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Competition Competition { get; set; } = default!;
        public List<Contestant> Contestants { get; set; } = [];
        public List<Score> Scores { get; set; } = [];
    }
}