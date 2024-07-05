namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class ProfileDTO
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int WaistSize { get; set; }
        public int ThighSize { get; set; }
        public Guid UserId { get; set; }
    }
}
