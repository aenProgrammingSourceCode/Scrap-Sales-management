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
   public class ConjunctionUserRepository:Repository<ConjunctionUser,int>,IConjunctionUserRepository
    {
       public ConjunctionUserRepository(IUnitOfWork uow):base(uow)
       {

       }
    }
}
