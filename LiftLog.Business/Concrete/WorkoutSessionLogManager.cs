
using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete.Utils;
using LiftLog.Data.Abstract;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models;

namespace LiftLog.Business.Concrete
{
    public class WorkoutSessionLogManager : ByUserProfileManager<WorkoutSessionLog, IWorkoutSessionLogRepository>, IWorkoutSessionLogService
    {
        public WorkoutSessionLogManager(IWorkoutSessionLogRepository repository) : base(repository) { }
    }
}
