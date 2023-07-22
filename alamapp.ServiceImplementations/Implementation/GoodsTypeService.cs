using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
using alamapp.Model.RepositoryInterface;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Types;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.Infrastructure.Domain;

namespace alamapp.ServiceImplementations.Implementation
{
   public class GoodsTypeService:IGoodsTypeService
    {
       private readonly IGoodsTypeRepository _goodsTypeRepository;
       private readonly IUnitOfWork _uow;
       public GoodsTypeService(IGoodsTypeRepository goodsTypeRepository, IUnitOfWork uow)
       {
           _goodsTypeRepository = goodsTypeRepository;
           _uow = uow;
       }

        public Messaging.Types.CreateGoodsTypeResponse CreateGoodsType(Messaging.Types.CreateGoodsTypeRequest request)
        {
            CreateGoodsTypeResponse response = new CreateGoodsTypeResponse();
            GoodsType goodsType = new GoodsType();
            goodsType.Name = request.Name;
            _goodsTypeRepository.Add(goodsType);

            //ThrowExceptionIfCustomerIsInvalid(goodsType);

            _uow.Commit();
            response.GoodsType = goodsType.ConvertToGoodsTypeView();
            return response;
        }
        //private void ThrowExceptionIfCustomerIsInvalid(GoodsType goodsType)
        //{
        //    if (goodsType.GetBrokenRules().Count() > 0)
        //    {
        //        StringBuilder brokenRules = new StringBuilder();
        //        brokenRules.AppendLine("There were problems saving the goods type:");
        //        foreach (BusinessRule businessRule in goodsType.GetBrokenRules())
        //        {
        //            brokenRules.AppendLine(businessRule.Rule);
        //        }

        //        throw new GoodsTypeInvalideException(brokenRules.ToString());

        //    }
        //}


        public GetAllGoodsTypeResponse GetAllGoodsType()
        {
            GetAllGoodsTypeResponse response = new GetAllGoodsTypeResponse();
            IEnumerable<GoodsType> goodsTypes = _goodsTypeRepository.FindAll();
            response.GoodsTypes = goodsTypes.ConvertToGoodsTypeViews();
            return response;
        }
    }
}
