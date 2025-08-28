

namespace Domain.Entities
{
    public class ScoringCriterion
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CriteriaName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CompetitionId { get; set; } = default!;
        public int MaxScore { get; set; }
        public int Weightage { get; set; }
        public Competition Competition { get; set; } = default!;
    }
}