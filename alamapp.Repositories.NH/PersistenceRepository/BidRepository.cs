using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Bids;
using alamapp.Model.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository
{
   public class BidRepository:Repository<Bid,int>,IBidRepository
    {
       public BidRepository(IUnitOfWork uow)
           : base(uow)
       {

       }
    }
}
