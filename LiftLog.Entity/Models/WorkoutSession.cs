using LiftLog.Entity.Models.CommonModels;

namespace LiftLog.Entity.Models
{
    public class WorkoutSession : HasUserProfileId
    {
        public Guid ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
