using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
using alamapp.Model.RepositoryInterface;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.LocalUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.ServiceImplementations.Mapping;
using alamapp.Infrastructure.Querying;
using alamapp.ServiceImplementations.Messaging.Authentications;
using alamapp.Model.RepositoryInterface.Customers;
using alamapp.Model.Customers;

namespace alamapp.ServiceImplementations.Implementation
{
   public class LocalUserService:ILocalUserService
    {
       private readonly ILocalUserRepository _localUserRepository;
       private readonly IConjunctionUserRepository _conjunctionUserRepository;
       private readonly IUnitOfWork _uow;
       private readonly ICompanyRepository _companyRepository;
       private readonly ICustomerRepository _customerRepository;
       public LocalUserService(ILocalUserRepository localUserRepository, 
           IUnitOfWork uow, 
           IConjunctionUserRepository conjunctionRepository,
           ICustomerRepository customerRepository,
           ICompanyRepository companyRepository)
        {
           _localUserRepository = localUserRepository;
           _uow = uow;
           _conjunctionUserRepository = conjunctionRepository;
           _companyRepository = companyRepository;
           _customerRepository = customerRepository;

        }
        public void CreateLocalUser(Messaging.LocalUsers.CreateLocalUserRequest request)
        {
                LocalUser localUser = new LocalUser();
                localUser.Email = request.Email;
                localUser.UserIdentityToken = request.UserIdentityToken;
                _localUserRepository.Add(localUser);
                _uow.Commit();
        }

        //private string GetExistingUserIdentityToken(string userIdentity)
        //{
        //    LocalUser localUser = _localUserRepository.FindBy(userIdentity);
        //    return localUser.UserIdentityToken;
        //}

        public GetLocalUserResponse GetLocalUser(Messaging.LocalUsers.GetLocalUserRequest request)
        {
            GetLocalUserResponse response = new GetLocalUserResponse();
            LocalUser localUser = _localUserRepository.FindBy(request.UserIdentityToken);
           
            response.LocalUser = localUser.ConvertToLocalUserView();
            return response;
        }
        public GetConjunctionUserResponse GetConjunctionUser(GetConjunctionUserRequest request)
        {
            ConjunctionUser ConjunctionUser = _conjunctionUserRepository.FindBy(request.Id);

            GetConjunctionUserResponse response = new GetConjunctionUserResponse();
            response.ConjunctionUser = ConjunctionUser.ConvertToConjunctionUserView();

            return response;

        }

        public int GetConjunctionId(GetConjunctionUserRequest request)
        {
            ConjunctionUser ConjunctionUser = _conjunctionUserRepository.FindBy(request.Id);

            GetConjunctionUserResponse response = new GetConjunctionUserResponse();
            response.ConjunctionUser = ConjunctionUser.ConvertToConjunctionUserView();

            return response.ConjunctionUser.CustomerId;
        }



        public void CreateConjunction(CreateConjunctionUserRequest request)
        {
            ConjunctionUser conjunctionUser=new ConjunctionUser();
            //Company company=_companyRepository.FindBy(request.CompanyId);
            //Customer customer=_customerRepository.FindBy(request.CustomerId);
            //conjunctionUser.Company = company;
            //conjunctionUser.Cu
            //_conjunctionUserRepository.Add(conjunctionUser);
        }
    }
}
