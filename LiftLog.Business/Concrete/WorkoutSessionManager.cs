using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete.Utils;
using LiftLog.Data.Abstract;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models;

namespace LiftLog.Business.Concrete
{
    public class WorkoutSessionManager : ByUserProfileManager<WorkoutSession, IWorkoutSessionRepository>, IWorkoutSessionService
    {
        public WorkoutSessionManager(IWorkoutSessionRepository repository) : base(repository) { }
    }
}
