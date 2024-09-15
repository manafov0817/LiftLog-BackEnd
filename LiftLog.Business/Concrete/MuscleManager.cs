using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete.Utils;
using LiftLog.Data.Abstract;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models;

namespace LiftLog.Business.Concrete
{
    public class MuscleManager : GenericManager<Muscle, IMuslceRepository>, IMuscleService
    {
        public MuscleManager(IMuslceRepository repository) : base(repository)
        {
        }
    }
}
