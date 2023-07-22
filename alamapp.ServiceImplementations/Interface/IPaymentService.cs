using alamapp.ServiceImplementations.Messaging.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IPaymentService
    {
       void CreatePayment(CreatePaymentRequest request);
       void ModifyPayment(ModifyPaymentRequest request);
       GetPaymentResponse GetPayment(GetPaymentRequest request);
       GetAllPaymentResponse GetAllPayments();
    }
}
