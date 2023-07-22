using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
using alamapp.Model.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository
{
   public class GlobalUserRepository:Repository<GlobalUser,string>,IGlobalUserRepository
    {
       public GlobalUserRepository(IUnitOfWork uow):
           base(uow)
       {

       }
    }
}
