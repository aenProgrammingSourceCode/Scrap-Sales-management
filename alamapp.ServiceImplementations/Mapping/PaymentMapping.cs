using alamapp.Model.Payments;
using alamapp.ServiceImplementations.ViewModel.Payments;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class PaymentMapping
    {
       public static PaymentView ConvertToPaymentView(this Payment payment)
       {
           return Mapper.Map<Payment, PaymentView>(payment);
       }

       public static IEnumerable<PaymentView> ConvertToPaymentViews(this IEnumerable<Payment> payments)
       {
           return Mapper.Map <IEnumerable<Payment>,IEnumerable<PaymentView>>(payments);
       }
    }
}
