using alamapp.Infrastructure.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Payments
{
   public class Transaction:EntityBase<int>
    {
        private Company _company;
        private Payment _payment;
        private int _balance;
        public Transaction()
        {

        }
        public Transaction(Company company, Payment payment, int balance)
        {
            // TODO: Complete member initialization
            _company = company;
            _payment = payment;
            _balance = balance;
        }

        public Company Company { get { return _company; } }
        public Payment Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
        public int Balance
        {
            get { return _balance; }
        }
        public void Deposit(int balance)
        {
           _balance += balance;
        }
        public bool Contains(Company company)
        {
            return Company == company;
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
