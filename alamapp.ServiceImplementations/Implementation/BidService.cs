using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
using alamapp.Model.Bids;
using alamapp.Model.Customers;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Customers;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.ServiceImplementations.Mapping;
using alamapp.Infrastructure.Querying;
using alamapp.ServiceImplementations.ViewModel;
using alamapp.Model.Categories;
using alamapp.Model.UserAuthentication;
using alamapp.Model.RepositoryInterface.Auth;
 

namespace alamapp.ServiceImplementations.Implementation
{
   public class BidService:IBidService
    {
      private readonly IConjunctionUserRepository _conjunctionUserRepository;
      private readonly IBidRepository _bidRepository;
      private readonly ICompanyRepository _companyRepository;
      private readonly ICustomerRepository _customerRepository;
      private readonly IProductRepository _productRepository;
      private readonly ICategoryRepository _categoryRepository;
      private readonly IGoodsTypeRepository _goodsTypeRepository;
      private readonly IApplyToBidRepository _applyToBidRepository;
      private readonly IAspUserRepository _aspUserRepository;
      private readonly IUnitOfWork _uow;
      public BidService(IBidRepository bidRepository,
           ICompanyRepository companyRepository,
           ICustomerRepository customerRepository,
           IProductRepository productRepository,
           IGoodsTypeRepository goodsTypeRepository,
           ICategoryRepository categoryRepository,
           IApplyToBidRepository applyToBidRepository,
           IUnitOfWork uow,
           IAspUserRepository aspUserRepository,
           IConjunctionUserRepository conjunctionUserRepository)
       {
           _bidRepository = bidRepository;
           _companyRepository = companyRepository;
           _customerRepository = customerRepository;
           _productRepository = productRepository;
           _conjunctionUserRepository = conjunctionUserRepository;
           _categoryRepository = categoryRepository;
           _goodsTypeRepository = goodsTypeRepository;
           _applyToBidRepository = applyToBidRepository;
           _aspUserRepository = aspUserRepository;
           _uow = uow;
       }
      public CreateBidResponse CreateBid(CreateBidRequest request)
       {
           CreateBidResponse response = new CreateBidResponse();
           
           Company company = _companyRepository.FindBy(request.CompanyId);
           Product product = _productRepository.FindBy(request.ProductId);
           GoodsType goodsType = _goodsTypeRepository.FindBy(request.GoodsTypeId);
           AspUser aspUser = _aspUserRepository.FindBy(request.UserIdentity);
           Bid bid = new Bid();
           
           bid.Company = company;
           bid.GoodsType = goodsType;
           bid.Product = product;
           bid.AspUser = aspUser;
           bid.Price = request.Price;
           bid.Qty = request.Qty;
           bid.ProductUnit = request.UnitId;
           decimal NetAmount = bid.GetAmount();
           bid.Amount = NetAmount;

           response.Bid = bid.ConvertToBidView();
           return response;
       }
      public void SaveBid(CreateBidRequest request)
       {
           
           Company company = _companyRepository.FindBy(request.CompanyId);
           Product product = _productRepository.FindBy(request.ProductId);
           GoodsType goodsType = _goodsTypeRepository.FindBy(request.GoodsTypeId);
           AspUser aspUser = _aspUserRepository.FindBy(request.UserIdentity);

           Bid bid = new Bid();
           bid.Company = company;
           bid.GoodsType = goodsType;
           bid.Product = product;
           bid.AspUser = aspUser;
           bid.Price = request.Price;
           bid.Qty = request.Qty;
           bid.ProductUnit = request.UnitId;
           decimal NetAmount = bid.GetAmount();
           bid.Amount = NetAmount;

           _bidRepository.Add(bid);
           _uow.Commit();

       }
      public Messaging.Bids.GetAllBidResponse GetAllBid()
       {
           GetAllBidResponse response = new GetAllBidResponse();
           IEnumerable<Bid> bids = _bidRepository.FindAll();
           response.Bids = bids.ConvertToBidViews();
           return response;
       }
      public IEnumerable<Bid> GetAllBidsMatchingRquestAndQuery(GetBidRequest request, Query bidQuery)
       {
           IEnumerable<Bid> bidMatchingQuery = _bidRepository.FindBy(bidQuery);
           return bidMatchingQuery;
       }
      public GetBidResponse GetBid(GetBidRequest request)
       {
           Query bidQuery = BidSearchQueryGenerator.CreateBidQuery(request);
           IEnumerable<Bid> bidMatching = GetAllBidsMatchingRquestAndQuery(request, bidQuery);
           GetBidResponse response=new GetBidResponse();
           response.Bids = bidMatching.ConvertToBidViews().Distinct();
           return response;
       }
      public GetBidResponse GetBidByBidId(GetBidRequest request)
       {
           Bid bid = _bidRepository.FindBy(request.Id);
           GetBidResponse response = new GetBidResponse();
           response.Bid =bid.ConvertToBidView();
           return response;
       }
      public GetBidResponse GetBidByGoodsType(GetBidRequest request)
       {
           Query bidQuery = BidSearchQueryGenerator.CreateBidForGoodsType(request);
           IEnumerable<Bid> bidMatching = GetAllBidsMatchingRquestAndQuery(request, bidQuery);
           GetBidResponse response = new GetBidResponse();
           response.Bids = bidMatching.ConvertToBidViews();
           return response;
       }
      public ModifyBidResponse ModifyBid(ModifyBidRequest request)
       {
           ModifyBidResponse response = new ModifyBidResponse();
           Bid bid = _bidRepository.FindBy(request.Id);
           Company company = _companyRepository.FindBy(request.CompanyId);
           Product product = _productRepository.FindBy(request.ProductId);
           Category category = _categoryRepository.FindBy(request.CategoryId);
           GoodsType goodsType = _goodsTypeRepository.FindBy(request.GoodsTypeId);
           bid.GoodsType = goodsType;
           bid.Category = category;
           bid.Company = company;
           bid.Product = product;
           bid.Price = request.Price;
           bid.Qty = request.Qty;
           bid.ProductUnit = request.UnitId;
           decimal NetAmount = bid.GetAmount();
           bid.Amount = NetAmount;
           bid.ExpiredDate = request.ExpiredDate;

           response.Bid = bid.ConvertToBidView();

           _bidRepository.Add(bid);
           _uow.Commit();

           return response;
       }
      public DeleteBidResponse DeleteBid(DeleteBidRequest request)
       {
           DeleteBidResponse response = new DeleteBidResponse();
           Bid bid = _bidRepository.FindBy(request.Id);

           response.Bid = bid.ConvertToBidView();
           _bidRepository.Delete(bid);
           _uow.Commit();
           return response;
       }
      public IEnumerable<ViewModel.BidView> GetBidPerProduct()
       {
           GetAllBidResponse response = new GetAllBidResponse();
           IEnumerable<Bid> bids = _bidRepository.FindAll();
           response.Bids = bids.ConvertToBidViews();

           var bidPerProduct = from bid in response.Bids
                               group bid by bid.ProductName into productBidGroup
                               select new BidView
                               {
                                   ProductId=productBidGroup.FirstOrDefault().ProductId,
                                   ProductName = productBidGroup.Key.ToString(),
                                   TotalBidByProduct= productBidGroup.Count()
                               };


           return bidPerProduct.ToList();
       }
      public IEnumerable<ViewModel.BidView> GetAppliedBidByApplied()
       {
           GetAllBidResponse response = new GetAllBidResponse();
           IEnumerable<Bid> bids = _bidRepository.FindAll();
           response.Bids = bids.ConvertToBidViews();

           var bidPerProduct = from bid in response.Bids
                               group bid by bid.ProductName into productBidGroup
                               select new BidView
                               {
                                   ProductId = productBidGroup.FirstOrDefault().ProductId,
                                   ProductName = productBidGroup.Key.ToString(),
                                   TotalBidByProduct = productBidGroup.Count()
                               };


           return bidPerProduct.ToList();
       }
      public IEnumerable<BidView> GetBidPerType()
       {
           GetAllBidResponse response = new GetAllBidResponse();
           IEnumerable<Bid> bids = _bidRepository.FindAll();
           response.Bids = bids.ConvertToBidViews();

           var bidPerGoodsType = from bid in response.Bids
                               group bid by bid.GoodsTypeName into bidGroupByType
                               select new BidView
                               {
                                   GoodsTypeId = bidGroupByType.FirstOrDefault().GoodsTypeId,
                                   GoodsTypeName = bidGroupByType.Key.ToString(),
                                   TotalBidByGoodsType = bidGroupByType.Count()
                               };


           return bidPerGoodsType.ToList();
       }
      public IEnumerable<Bid> GetBidBy(GetBidRequest request, Query bidQuery)
       {
           IEnumerable<Bid> bidMatchingQuery = _bidRepository.FindBy(bidQuery);
           return bidMatchingQuery;
       }
      private IEnumerable<Bid> GetAllBidsMatchingQuery(Query bidQuery)
       {
           IEnumerable<Bid> bidMatchingQuery = _bidRepository.FindBy(bidQuery);
           return bidMatchingQuery;
       }
      private IEnumerable<ApplyToBid> GetAllApplyToBidMatchingQuery(Query bidQuery)
       {
           IEnumerable<ApplyToBid> applyToBidMatchingQuery =_applyToBidRepository.FindBy(bidQuery);
           return applyToBidMatchingQuery;
       }
      public GetAllBidByCompanyUserResponse GetAllBidByUserOfCompany(GetAllBidByCompanyUserRequest request)
       {
           AspUser aspUser =_aspUserRepository.FindBy(request.UserIdentityToken);
           Query getAllBidByUserQuery = BidSearchQueryGenerator.CreateBidQueryForCompany(aspUser.Id);
           IEnumerable<Bid> bids = GetAllBidsMatchingQuery(getAllBidByUserQuery);
           GetAllBidByCompanyUserResponse response = new GetAllBidByCompanyUserResponse();
           response.Bids =bids.ConvertToBidViews();

           var BidList = response.Bids.Distinct().Select(apply => new BidView
           {
               Id = apply.Id,
               CompanyName = apply.CompanyName,
               ProductName = apply.ProductName,
               Price = apply.Price,
               Qty = apply.Qty,
               CreatedDate = apply.CreatedDate,
               Amount = apply.Amount,
               TotalApply = apply.ApplyToBids.Count(),
               ProductUnit=apply.ProductUnit,
               BalanceQty=apply.BalanceQty,
               NetQuantity=apply.NetQuantity,
               CountSold=apply.CountSold
                
           });

           response.Bids = BidList.ToList();
           return response;
       }
      public GetApplyBidByCustomerResponse GetApplyToBidByCompany(GetApplyBidByCustomerRequest request)
       {
           Query applyBidByQuery = BidSearchQueryGenerator.CreateApplyBidForQuery(request.BidId);
           IEnumerable<ApplyToBid> applyToBids = GetAllApplyToBidMatchingQuery(applyBidByQuery);
           GetApplyBidByCustomerResponse response = new GetApplyBidByCustomerResponse();
           response.ApplyToBids = applyToBids.ConvertToApplyToBidViews();
           return response;
       }
      public GetApplyBidByCustomerResponse GetApplyToBidByCustomer(GetApplyBidByCustomerRequest request)
       {
           Customer customer = _customerRepository.FindBy(request.UserIdentityToken);
           Query applyBidByQuery = BidSearchQueryGenerator.CreateApplyBidByCustomerForQuery(customer.Id);
           IEnumerable<ApplyToBid> applyToBids = GetAllApplyToBidMatchingQuery(applyBidByQuery);
           GetApplyBidByCustomerResponse response = new GetApplyBidByCustomerResponse();
           response.ApplyToBids = applyToBids.ConvertToApplyToBidViews();
           return response;
       }
      public void ModifyApplyToBidByCompany(ModifyAppliedBidRequest request)
       {
           ApplyToBid appliedToBid = _applyToBidRepository.FindBy(request.Id);
           appliedToBid.IsSold = request.IsSold;
           appliedToBid.SoldDate = DateTime.Now.ToString();
           appliedToBid.Msg = request.Msg;
           _applyToBidRepository.Save(appliedToBid);
           _uow.Commit();
       }
      public GetAppliedBidSoldItemResponse GetSoldItemByCompany(GetAppliedBidSoldItemRequest request)
       {
           GetAppliedBidSoldItemResponse response = new GetAppliedBidSoldItemResponse();
           Query applyBidByQuery = BidSearchQueryGenerator.CreateAppliedBidSoldItemForCustomer(request.IsSold);
           IEnumerable<ApplyToBid> applyToBids = GetAllApplyToBidMatchingQuery(applyBidByQuery);
           response.ApplyToBids = applyToBids.ConvertToApplyToBidViews();
           return response;
       }
      public GetAppliedBidSoldItemResponse GetSoldItemByCustomer(GetAppliedBidSoldItemRequest request)
       {
           GetAppliedBidSoldItemResponse response = new GetAppliedBidSoldItemResponse();
           Query applyBidByQuery = BidSearchQueryGenerator.CreateAppliedBidSoldItemForCustomer(request.IsSold);
           IEnumerable<ApplyToBid> applyToBids = GetAllApplyToBidMatchingQuery(applyBidByQuery);
           response.ApplyToBids = applyToBids.ConvertToApplyToBidViews();
           return response;
       }
      public IEnumerable<BidView> CountApplyToBidByBid()
       {
           GetAllBidResponse response = new GetAllBidResponse();
           IEnumerable<Bid> bids = _bidRepository.FindAll();
           response.Bids = bids.ConvertToBidViews();
          
          var BidList =response.Bids.Distinct().Select(apply=>new BidView
               {
                   Id=apply.Id,
                   CompanyName=apply.CompanyName,
                   ProductName=apply.ProductName,
                   Price=apply.Price,
                   Qty=apply.Qty,
                   CreatedDate=apply.CreatedDate,
                   Amount=apply.Amount,
                   TotalApply=apply.ApplyToBids.Count()
               });
          return BidList.ToList();

       }
      public CreateApplyBidByCustomerResponse ApplyBidByCustomer(CreateApplyBidByCustomerRequest request)
       {
           CreateApplyBidByCustomerResponse response = new CreateApplyBidByCustomerResponse();
           Customer customer = _customerRepository.FindBy(request.UserIdentityToken);
           Bid bid = _bidRepository.FindBy(request.BidId);
           bid.AddToApplyToBid(customer, request.Price, request.Quantity, request.Msg, request.IsSold, request.SoldDate, bid,request.ProductUnit);
           _bidRepository.Save(bid);
           _uow.Commit();
           response.Bid = bid.ConvertToBidView();
           return response;
       }
      public GetSoldItemForCustomerResponse GetSoldItemForCustomer(GetSoldItemForCustomerRequest request)
      {
          GetSoldItemForCustomerResponse response = new GetSoldItemForCustomerResponse();
          Customer customer = _customerRepository.FindBy(request.IdentityToken);
          Query applyBidByQuery = BidSearchQueryGenerator.CreateSoldItemForCustomer(customer.Id);
          IEnumerable<ApplyToBid> applyToBids = GetAllApplyToBidMatchingQuery(applyBidByQuery);
          response.ApplyToBids = applyToBids.ConvertToApplyToBidViews();
          return response;
      }
    }

     
}

 
