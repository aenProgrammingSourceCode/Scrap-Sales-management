using alamapp.Model;
using alamapp.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class ApplyToBidMapping
   {
       public static ApplyToBidView ConvertToApplyToBidView(this ApplyToBid applyToBid)
       {
           return Mapper.Map<ApplyToBid, ApplyToBidView>(applyToBid);
       }
       public static IEnumerable<ApplyToBidView> ConvertToApplyToBidViews(this IEnumerable<ApplyToBid> applyToBids)
       {
           return Mapper.Map<IEnumerable<ApplyToBid>, IEnumerable<ApplyToBidView>>(applyToBids);
       }
    }
}
