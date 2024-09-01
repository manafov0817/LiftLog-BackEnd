
using LiftLog.Entity.Enums;
using LiftLog.Entity.Models.CommonModels;

namespace LiftLog.Entity.Models
{
    public class UserProfile : HasId
    {
        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int WaistSize { get; set; }
        public int ThighSize { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
