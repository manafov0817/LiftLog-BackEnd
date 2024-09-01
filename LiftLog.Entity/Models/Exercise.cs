using LiftLog.Entity.Enums;
using LiftLog.Entity.Models.CommonModels;

namespace LiftLog.Entity.Models
{
    public class Exercise : HasUserProfileId
    {
        public string? MovementName { get; set; }
        public WeightType WeightType { get; set; }
        public byte SetCount { get; set; }
        public int MovementId { get; set; }
        public Movement Movement { get; set; }
    }
}
