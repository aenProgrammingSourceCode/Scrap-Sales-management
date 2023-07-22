using alamapp.ServiceImplementations.Messaging.Bids;
using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IBidService
    {
       CreateBidResponse CreateBid(CreateBidRequest request);
       GetAllBidResponse GetAllBid();
       GetBidResponse GetBid(GetBidRequest request);
       ModifyBidResponse ModifyBid(ModifyBidRequest request);
       DeleteBidResponse DeleteBid(DeleteBidRequest request);
       IEnumerable<BidView> GetBidPerProduct();
       IEnumerable<BidView> GetBidPerType();
       CreateApplyBidByCustomerResponse ApplyBidByCustomer(CreateApplyBidByCustomerRequest request);
       GetAllBidByCompanyUserResponse GetAllBidByUserOfCompany(GetAllBidByCompanyUserRequest request);
       GetApplyBidByCustomerResponse GetApplyToBidByCompany(GetApplyBidByCustomerRequest request);
       GetApplyBidByCustomerResponse GetApplyToBidByCustomer(GetApplyBidByCustomerRequest request);
       void SaveBid(CreateBidRequest request);
       GetBidResponse GetBidByGoodsType(GetBidRequest request);
       void ModifyApplyToBidByCompany(ModifyAppliedBidRequest request);
       GetAppliedBidSoldItemResponse GetSoldItemByCompany(GetAppliedBidSoldItemRequest request);
       GetAppliedBidSoldItemResponse GetSoldItemByCustomer(GetAppliedBidSoldItemRequest request);
       IEnumerable<BidView> CountApplyToBidByBid();
       GetBidResponse GetBidByBidId(GetBidRequest request);
       GetSoldItemForCustomerResponse GetSoldItemForCustomer(GetSoldItemForCustomerRequest request);
    }
}

