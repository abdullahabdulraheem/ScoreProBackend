using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contestant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string CompetitionId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string TeamId { get; set; } = default!;
        public int AverageScore { get; set; }
        public int TotalScore { get; set; }
        public User User { get; set; } = default!;
        public Competition Competition { get; set; } = default!;
        public Team? Team { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public List<Score> Scores { get; set; } = [];
    }
}