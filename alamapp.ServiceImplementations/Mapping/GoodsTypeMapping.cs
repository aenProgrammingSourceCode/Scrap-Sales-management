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
   public static class GoodsTypeMapping
   {
       public static GoodsTypeView ConvertToGoodsTypeView(this GoodsType goodsType)
       {
           return Mapper.Map<GoodsType, GoodsTypeView>(goodsType);
       }

       public static IEnumerable<GoodsTypeView> ConvertToGoodsTypeViews(this IEnumerable<GoodsType> goodsTypes)
       {
           return Mapper.Map<IEnumerable<GoodsType>, IEnumerable<GoodsTypeView>>(goodsTypes);
       }
    }
}
