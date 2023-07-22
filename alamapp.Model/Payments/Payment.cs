using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Payments
{
   public class Payment:EntityBase<string>,IAggregateRoot
    {
       private IList<Transaction> _transactions;
      
       public Payment()
       {
           _transactions = new List<Transaction>();
           PaymentDate = DateTime.Now;
       }
       public DateTime PaymentDate { get; set; }
       public void AddToPayment(Company company,int amount)
       {
           if (PaymentContainsTransaction(company))
               GetTransactionFor(company).Deposit(amount);
           else
               _transactions.Add(TransactionFactory.CreateTransactionFor(company, this, amount));
       }
       public Transaction GetTransactionFor(Company company)
       {
           return _transactions.Where(i => i.Contains(company)).FirstOrDefault();
       }
       public bool PaymentContainsTransaction(Company company)
       {
          return _transactions.Any(i => i.Contains(company));
       }
       public IEnumerable<Transaction> Transactions
       {
           get { return _transactions; }
       }




       protected override void Validate()
       {
           throw new NotImplementedException();
       }
    }
}
