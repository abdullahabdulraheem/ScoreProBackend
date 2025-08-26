using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Judge
    {
        public string Id = new Guid().ToString();
        public string CompetitionId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public int Rating { get; set; } = default!;
        public User User { get; set; }
        public Competition Competition { get; set; }
    }
}