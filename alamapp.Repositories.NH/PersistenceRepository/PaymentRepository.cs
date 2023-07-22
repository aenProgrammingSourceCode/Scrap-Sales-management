using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.SBCB
{
   public class PaymentRepository:Repository<Payment,string>,IPaymentRepository
    {
       public PaymentRepository(IUnitOfWork uow)
           :base(uow)
       {

       }
    }
}
