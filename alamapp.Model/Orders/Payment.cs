using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public class Payment:ValueObjectBase
    {
        private string _transactionId;

        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }
        private decimal _amount;

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _paymentMerchant;

        public string PaymentMerchant
        {
            get { return _paymentMerchant; }
            set { _paymentMerchant = value; }
        }
        private DateTime _paymentDate;

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }
        
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
