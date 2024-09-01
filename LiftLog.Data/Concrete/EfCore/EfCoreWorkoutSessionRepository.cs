using LiftLog.Data.Abstract;
using LiftLog.Data.Concrete.EfCore.Utils;
using LiftLog.Entity.Models; 

namespace LiftLog.Data.Concrete.EfCore
{
    public class EfCoreWorkoutSessionRepository : EfCoreByUserProfileRepository<WorkoutSession>, IWorkoutSessionRepository { }
}
