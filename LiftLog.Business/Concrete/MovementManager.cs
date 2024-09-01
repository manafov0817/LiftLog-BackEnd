using LiftLog.Business.Abstract;
using LiftLog.Business.Concrete.Utils;
using LiftLog.Data.Abstract;
using LiftLog.Data.Abstract.Utils;
using LiftLog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLog.Business.Concrete
{
    public class MovementManager : ByUserProfileManager<Movement, IMovementRepository>, IMovementService
    {
        public MovementManager(IByUserProfileRepository<Movement> repository) : base(repository) { }
    }
}
