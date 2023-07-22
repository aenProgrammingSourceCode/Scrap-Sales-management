using alamapp.Infrastructure.Domain;
using alamapp.Model.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface
{
   public interface IBidRepository:IRepository<Bid,int>
    {

    }
}
