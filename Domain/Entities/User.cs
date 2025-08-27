using Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ProfileImageUrl { get; set; } = default!;
        public string UserType { get; set; } = UserRole.Registered.ToString();
        public List<Competition> Competitions { get; set; } = default!;
        public int CometitionsContestedIn { get; set; }
        public int CompetitionsWon { get; set; }
        public int CompetitionsJudged { get; set; }
        public int AllTimeRating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}