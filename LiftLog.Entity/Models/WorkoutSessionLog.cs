using LiftLog.Entity.Models.CommonModels; 

namespace LiftLog.Entity.Models
{
    public class WorkoutSessionLog : HasUserProfileId
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WorkoutSessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; }
    }
}
