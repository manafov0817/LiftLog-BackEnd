using LiftLog.Entity.Models.CommonModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftLog.Entity.Models
{
    public class Movement : HasUserProfileId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public List<Guid> MuscleIds { get; set; }
    }
}
