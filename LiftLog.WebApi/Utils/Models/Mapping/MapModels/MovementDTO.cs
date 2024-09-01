using LiftLog.Entity.Enums;

namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class MovementDTO : HasUserId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Muscle MusclesEngaged { get; set; }
        public string VideoLink { get; set; }
    }
}
