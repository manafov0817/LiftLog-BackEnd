namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class MovementDTO  
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? VideoLink { get; set; }
        public List<Guid>? MuscleIds { get; set; }
    }
}
