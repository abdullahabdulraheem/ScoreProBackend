using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contestant
    {
        public string Id { get; set; } = new Guid().ToString();
        public string CompetitionId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public int JudgesCount { get; set; }
        public int AverageScore { get; set; }
        public User User { get; set; }
        public Competition Competition { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}