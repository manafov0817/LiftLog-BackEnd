using LiftLog.Entity.Models;

namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class MovementDTO  
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Muscle MusclesEngaged { get; set; }
        public string VideoLink { get; set; }
    }
}
