namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class WorkoutSessionLogDTO : HasUserId
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WorkoutSessionId { get; set; }
    }
}
