using alamapp.Model;
using alamapp.Model.Baskets;
using alamapp.Model.Bids;
using alamapp.Model.Categories;
using alamapp.Model.Customers;
using alamapp.Model.Packages;
using alamapp.Model.Payments;
using alamapp.Model.Products;
using alamapp.Model.UserAuthentication;
using alamapp.ServiceImplementations.ViewModel;
using alamapp.ServiceImplementations.ViewModel.Authentications;
using alamapp.ServiceImplementations.ViewModel.Baskets;
using alamapp.ServiceImplementations.ViewModel.Brands;
using alamapp.ServiceImplementations.ViewModel.Customers;
using alamapp.ServiceImplementations.ViewModel.Manufactures;
using alamapp.ServiceImplementations.ViewModel.Orders;
using alamapp.ServiceImplementations.ViewModel.Packages;
using alamapp.ServiceImplementations.ViewModel.Payments;
using alamapp.ServiceImplementations.ViewModel.Product;
using alamapp.ServiceImplementations.ViewModel.ProductModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations
{
   public class AutoMapperBootStrapper
    {
       public static void ConfigureAutoMapper()
       {
           // Category mapper
           Mapper.CreateMap<Category, CategoryView>();
           Mapper.CreateMap<ProductTitle, ProductView>();
           Mapper.CreateMap<Product, ProductView>();
           //  .ForMember(dest => dest.ProductImageViews,
           //             opt => opt.MapFrom(src => src.Title.ProductImage))
           //.ForMember(dest => dest.ProductTitleId,
           //             opt => opt.MapFrom(src => src.Title.Id));


           Mapper.CreateMap<Manufacture, ManufactureView>();
           Mapper.CreateMap<ProductModel, ProductModelView>();
           Mapper.CreateMap<Brand, BrandView>();
           Mapper.CreateMap<ProductTitle, ProductTitleView>();
           Mapper.CreateMap<Product, ProductTitleView>();
           Mapper.CreateMap<Package, PackageView>();
           Mapper.CreateMap<PackageItem, PackageItemView>();
           
               

           Mapper.CreateMap<Basket, BasketView>()
             .ForMember(dest => dest.BasketItemViews,
                        opt => opt.MapFrom(src => src.BasketItems));
               
           Mapper.CreateMap<BasketItem, BasketItemView>();
           Mapper.CreateMap<ProductImage, ProductImageView>();
           Mapper.CreateMap<Customer, CustomerView>();
           Mapper.CreateMap<Payment, PaymentView>();
              
           
           Mapper.CreateMap<Transaction, TransactionView>();
           
           //Aspnet Authentication
           Mapper.CreateMap<LocalUser, LocalUserView>();
           Mapper.CreateMap<AspRole, AspRoleView>();
           Mapper.CreateMap<AspUserRole, AspUserRoleView>();
           Mapper.CreateMap<ConjunctionUser, ConjunctionUserView>();

           Mapper.CreateMap<Bid, BidView>();

           Mapper.CreateMap<Company, CompanyView>();
           Mapper.CreateMap<CustomerResponseForBid, CustomerResponseForBidView>();
           Mapper.CreateMap<Bid, BidView>();
                    
           Mapper.CreateMap<GoodsType, GoodsTypeView>();
           Mapper.CreateMap<ApplyToBid,ApplyToBidView>();


       }
    }
}

