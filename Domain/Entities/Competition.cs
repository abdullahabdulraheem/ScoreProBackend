using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Competition
    {
        public string Id { get; set; } = new Guid().ToString();
        public string CompetitionName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CompetitionImageUrl { get; set; } = default!;
        public string CreatedByUserId { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public List<Judge> AssignedJudges { get; set; }
        public List<Contestant> Contestants { get; set; }
        public List<Team> Teams { get; set; }
    }
}