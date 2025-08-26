using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team
    {
        public string Id = new Guid().ToString();
        public string TeamName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string TeamLogoUrl { get; set; } = default!;
        public string CompetitionId { get; set; } = default!;
        public string CreatedByUserId { get; set; } = default!;
        public Competition Competition { get; set; }
        public List<Contestant> TeamMembers { get; set; }

    }
}