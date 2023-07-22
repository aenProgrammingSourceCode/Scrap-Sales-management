using alamapp.Infrastructure.Domain;
using alamapp.Model.Bids;
using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface
{
    public interface CustomerResponseForBidRepository : IRepository<CustomerResponseForBid, int>
    {

    }
}
