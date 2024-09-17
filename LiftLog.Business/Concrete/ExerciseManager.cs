using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete.Utils;
using LiftLog.Data.Abstract;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models;

namespace LiftLog.Business.Concrete
{
    public class ExerciseManager : ByUserProfileManager<Exercise, IExerciseRepository>, IExerciseService
    {
        public ExerciseManager(IExerciseRepository repository) : base(repository)
        { }
    }
}
