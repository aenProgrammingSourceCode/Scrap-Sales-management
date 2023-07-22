using alamapp.ServiceImplementations.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Types
{
   public class GetAllGoodsTypeResponse
    {
        public IEnumerable<GoodsTypeView> GoodsTypes { get; set; }
    }
}
