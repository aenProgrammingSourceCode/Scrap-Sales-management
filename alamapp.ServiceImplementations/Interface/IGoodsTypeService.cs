using alamapp.ServiceImplementations.Messaging.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
  public interface IGoodsTypeService
    {
      CreateGoodsTypeResponse CreateGoodsType(CreateGoodsTypeRequest request);
      GetAllGoodsTypeResponse GetAllGoodsType();
    }
}
