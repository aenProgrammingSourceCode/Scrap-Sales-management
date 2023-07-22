using alamapp.Model.Bids;
using alamapp.ServiceImplementations.Messaging.Bids;
using alamapp.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class BidMapping
    {
       public static GetBidResponse CreateBidSearchResultFrom(this IEnumerable<Bid> bidFound, GetBidRequest request)
       {
           GetBidResponse response = new GetBidResponse();
           response.TotalBids = bidFound.Count();
           response.TotalPages = NoOfResultPagesGiven(request.PageSize, response.TotalBids);
           response.Bids = CropProductListToSatisfyGivenIndex(request.Index, request.PageSize, bidFound);
           return response;
       }

        private static IEnumerable<BidView> CropProductListToSatisfyGivenIndex(int pageIndex, int pageSize, IEnumerable<Bid> bidsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * pageSize;
                return bidsFound.Skip(numToSkip).Take(pageSize).ConvertToBidViews();
            }
            else
                return bidsFound.Take(pageSize).ConvertToBidViews();
        }

        private static int NoOfResultPagesGiven(int pageSize, int totalBid)
        {
            if (totalBid < pageSize)
                return 0;
            else
            {
                return (totalBid / pageSize) + (totalBid % pageSize);
            }
        }

       public static BidView ConvertToBidView(this Bid bid)
       {
           return Mapper.Map<Bid, BidView>(bid);
       }
       public static IEnumerable<BidView> ConvertToBidViews(this IEnumerable<Bid> bids)
       {
           return Mapper.Map<IEnumerable<Bid>,IEnumerable<BidView>>(bids);
       }
    }
}
