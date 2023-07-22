using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
using alamapp.Model.Payments;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Auth;
using alamapp.Model.UserAuthentication;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Messaging.Company;
using alamapp.ServiceImplementations.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.Infrastructure.Querying;


namespace alamapp.ServiceImplementations.Implementation
{
   public class CompanyService:ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILocalUserRepository _localUserRepository;
        private readonly IUnitOfWork _uow;
        private readonly IAspUserRepository _aspUserRepository;
        public CompanyService(ICompanyRepository companyRepository, 
            IUnitOfWork uow, ILocalUserRepository localUserRepository,
            IAspUserRepository aspUserRepository)
        {
            _uow = uow;
           _companyRepository = companyRepository;
           _localUserRepository = localUserRepository;
           _aspUserRepository = aspUserRepository;
        }
        public CreateCompanyResponse CreateCompany(Messaging.Company.CreateCompanyRequest request)
        {
            CreateCompanyResponse response = new CreateCompanyResponse();
            AspUser aspUser = _aspUserRepository.FindBy(request.UserIdentity);
            Company company = new Company();
            company.Name = request.Name;
            company.UserName = request.AdminUserName;
            company.Position = request.AdminUserPosition;
            company.AspUser = aspUser;

            response.Company = company.ConvertToCompanyView();
 
            return response;
        }

        public void SaveCompany(Messaging.Company.CreateCompanyRequest request)
        {
            AspUser aspUser = _aspUserRepository.FindBy(request.UserIdentity);
            Company company = new Company();
            company.Name = request.Name;
            company.UserName = request.AdminUserName;
            company.Position = request.AdminUserPosition;
            company.AspUser = aspUser;
            _companyRepository.Add(company);
            _uow.Commit();
        }
        private IEnumerable<Company> GetAllCompanyByMatchingQuery(Query bidQuery)
        {
            IEnumerable<Company> companyMatchingQuery =_companyRepository.FindBy(bidQuery);
            return companyMatchingQuery;
        }
        public Messaging.Company.GetCompanyResponse GetCompany(Messaging.Company.GetCompanyRequest request)
        {
            Query companyByUserQuery = CompanySearchQueryGenerator.CreateComapnyForQuery(request.UserIdentityToken);
            IEnumerable<Company> MatchingCompany =GetAllCompanyByMatchingQuery(companyByUserQuery);
            GetCompanyResponse response = new GetCompanyResponse();
            response.Companies=MatchingCompany.ConvertToCompanyViews();
            return response;
        }

        public Messaging.Company.ModifyCompanyResponse ModifyCompany(Messaging.Company.ModifyCompanyRequest request)
        {
            ModifyCompanyResponse response = new ModifyCompanyResponse();
            return response;
        }

        public Messaging.Company.DeleteCompanyResponse DeleteCompany(Messaging.Company.DeleteCompanyRequest request)
        {
            DeleteCompanyResponse response = new DeleteCompanyResponse();
            return response;
        }

        
        public Messaging.Company.GetAllCompanyResponse GetAllCompany()
        {
            GetAllCompanyResponse response = new GetAllCompanyResponse();
            IEnumerable<Company> company = _companyRepository.FindAll();
            response.Companies= company.ConvertToCompanyViews();
            
            return response;
        }
    }
}
