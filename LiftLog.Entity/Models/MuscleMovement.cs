namespace LiftLog.Entity.Models
{
    public class MuscleMovement
    {
        public Guid MuscleId { get; set; }
        public Muscle Muscle { get; set; }
        public Guid MovementId { get; set; }
        public Movement Movement { get; set; }
    }
}
