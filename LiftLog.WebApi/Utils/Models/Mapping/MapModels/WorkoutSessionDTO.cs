using Microsoft.AspNetCore.Authorization;

namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{

    public class WorkoutSessionDTO : HasUserId
    {
        public Guid ExerciseId { get; set; }
    }
}
