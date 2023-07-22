using alamapp.Infrastructure.Domain;
using alamapp.Model.Categories;
using alamapp.Model.Customers;
using alamapp.Model.Products;
using alamapp.Model.UserAuthentication;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Bids
{
   public class Bid:EntityBase<int>, IAggregateRoot
    {
       private List<CustomerResponseForBid> _customerResponse;
       private IList<ApplyToBid> _applyToBids;
       public Bid()
       {
           _applyToBids = new List<ApplyToBid>();
           _customerResponse = new List<CustomerResponseForBid>();
           CreatedDate =DateTime.Now.ToString();
           ExpiredDate = DateTime.Now.AddDays(6);
       }

       public int CountSold
       {
           get { return _applyToBids.Where(a => a.IsSold == true).Count(); }
       }

       public decimal BalanceQty
       {
           get { return _applyToBids.Where(a=>a.IsSold==true).Sum(a => a.Bid.Qty - a.Qty); }
       }
       public decimal QuantityAllocation()
       {
           if (BalanceQty ==0)
           {
               return Qty;
           }
           else
               return BalanceQty; 
       }
       public string NetQuantity
       {
           get { return String.Format(CultureInfo.InvariantCulture, "{0:0,0.0}", QuantityAllocation()); }
       }
        
       public decimal GetAppliedBid
       {
         get {return _applyToBids.Where(a => a.IsSold = true).FirstOrDefault().Qty;}
       }
       public void AddToApplyToBid(Customer customer,decimal price,decimal qty,string msg,bool isSold,string soldDate,Bid bid,string productUnit)
       {
           if (BidAppliedFor(customer,bid) == false)
           {
             _applyToBids.Add(ApplyBidFactory.CreateApplyToBid(bid, customer, price, qty, msg, soldDate, isSold,productUnit));
           }
           else
           {
               throw new Exception("You have already applied");
           }
       }

       public bool BidAppliedFor(Customer customer,Bid bid)
       {
           return _applyToBids.Any(a => a.ContainCustomer(customer,bid));
       }
       public IEnumerable<ApplyToBid> ApplyToBids
       {
           get { return _applyToBids; }
       }
       private int TotalAppliedCustomer
       {
           get
           {
               return _applyToBids.Sum(a => a.Bid.Id);
           }
       }
       public string CreatedDate { get; set; }
       public List<CustomerResponseForBid> CustomerResponse
       {
           get { return _customerResponse; }
           set { _customerResponse = value; }
       }
        public int NumberOfAppliedBid 
        {
            get { return _customerResponse.Count(); }
        }

        private DateTime _expiredDate;
        public DateTime ExpiredDate
        {
            get { return _expiredDate; }
            set { _expiredDate = value; }
        }
       

        private Category _category;
        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }
        private GoodsType _goodsType;

        public GoodsType GoodsType
        {
            get { return _goodsType; }
            set { _goodsType = value; }
        }
       
        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; }
        }
     
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private decimal _amount;

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private decimal _qty;

        public decimal Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        private string _productUnit;

        public string ProductUnit
        {
            get { return _productUnit; }
            set { _productUnit = value; }
        }
       
        private AspUser _aspUser;

        public AspUser AspUser
        {
            get { return _aspUser; }
            set { _aspUser = value; }
        }
        public decimal GetAmount()
        {
            if(ProductUnit=="Lot")
            {
                Qty = 1;
               return Amount = Price * Qty;
            }
            else
            {
               return Amount=Price*Qty;
            }
        }
        public int Count { get; set; }
        
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
