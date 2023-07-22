using alamapp.Infrastructure.Querying;
using alamapp.Model;
using alamapp.Model.Bids;
using alamapp.ServiceImplementations.Messaging.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public static class BidSearchQueryGenerator
    {
       public static Query CreateBidQuery(GetBidRequest getBidRequest)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery= new Query();

           productModelQuery.Add(Criterion.Create<Bid>(b => b.Product.Id, getBidRequest.ProductId, CriteriaOperator.Equel));
           return productModelQuery;
       }


       public static Query CreateBidForGoodsType(GetBidRequest getBidRequest)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<Bid>(b => b.GoodsType.Id, getBidRequest.GoodsTypeId, CriteriaOperator.Equel));
           return productModelQuery;
       }

       public static Query CreateBidQueryForCompany(string userId)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<Bid>(b => b.AspUser.Id, userId, CriteriaOperator.Equel));
           
           return productModelQuery;
       }

       public static Query CreateApplyBidForQuery(int bidId)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<ApplyToBid>(b => b.Bid.Id, bidId, CriteriaOperator.Equel));

           return productModelQuery;
       }

       public static Query CreateApplyBidByCustomerForQuery(int customerId)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<ApplyToBid>(b => b.Customer.Id, customerId, CriteriaOperator.Equel));

           return productModelQuery;
       }

       public static Query CreateAppliedBidSoldItemForCustomer(bool isSold)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<ApplyToBid>(b => b.IsSold, isSold, CriteriaOperator.Equel));

           return productModelQuery;
       }


       public static Query CreateCustomerQueryForAppliedBid(string userIdentity)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<ApplyToBid>(b => b.Customer.AspUser.Id,userIdentity, CriteriaOperator.Equel));

           return productModelQuery;
       }

       public static Query CreateSoldItemForCustomer(int customerId)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<ApplyToBid>(b => b.Customer.Id,customerId, CriteriaOperator.Equel));
           productModelQuery.Add(Criterion.Create<ApplyToBid>(b => b.IsSold,true, CriteriaOperator.Equel));

           return productModelQuery;
       }
    }
}
