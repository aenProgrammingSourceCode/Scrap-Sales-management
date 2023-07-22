using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Payments
{
   public static class TransactionFactory
    {
       public static Transaction CreateTransactionFor(Company company, Payment payment, int balance)
       {
           return new Transaction(company, payment, balance);
       }
    }
}
