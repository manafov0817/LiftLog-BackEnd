using LiftLog.Entity.Enums;
using LiftLog.Entity.Models;

namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class ExerciseDTO:HasUserId
    {
        public string MovementName { get; set; }
        public WeightType WeightType { get; set; }
        public byte SetCount { get; set; }
        public int MovementId { get; set; }
    }
}
