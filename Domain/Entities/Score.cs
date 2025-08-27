using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Score
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ContestantId { get; set; } = default!;
        public string TeamId { get; set; } = default!;
        public string JudgeId { get; set; } = default!;
        public int Value { get; set; }

        public Contestant Contestant { get; set; } = default!;
        public Judge Judge { get; set; } = default!;
        public Team Team { get; set; } = default!;
    }

}