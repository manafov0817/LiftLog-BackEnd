using LiftLog.Entity.Models.CommonModels;

namespace LiftLog.Entity.Models
{
    public class Movement : HasUserProfileId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public List<MuscleMovement> MuscleMovements { get; set; }
    }
}
