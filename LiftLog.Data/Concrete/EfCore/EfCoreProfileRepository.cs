using LiftLog.Data.Abstract;
using LiftLog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLog.Data.Concrete.EfCore
{
    public class EfCoreProfileRepository : GenericRepository<Profile, EfDbContext>, IProfileRepository { }
}
