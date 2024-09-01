using LiftLog.Entity.Enums;

namespace LiftLog.WebApi.Utils.Models.Mapping.MapModels
{
    public class ProfileDTO : HasUserId
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int WaistSize { get; set; }
        public int ThighSize { get; set; }
    }
}
