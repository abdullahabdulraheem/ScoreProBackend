using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Judge
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } = default!;
        public int Rating { get; set; }
        public User User { get; set; } = default!;
        public List<Competition> CompetitionAssignments { get; set; } = default!;
        public List<Score> Scores { get; set; } = [];
    }
}