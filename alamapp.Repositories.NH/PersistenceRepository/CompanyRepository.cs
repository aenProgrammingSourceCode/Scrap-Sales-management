using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
using alamapp.Model.Payments;
using alamapp.Model.RepositoryInterface;
using alamapp.Repositories.NH.SessionStorage;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository
{
   public class CompanyRepository:Repository<Company,int>,ICompanyRepository
    {
       public CompanyRepository(IUnitOfWork uow)
           :base(uow)
       {

       }
       public Company FindBy(string userIdentityToken)
       {
           ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                    .CreateCriteria(typeof(Company))
                    .Add(Expression.Eq(PropertyNameHelper
                    .ResolvePropertyName<Company>
                   (c => c.AspUser.Id), userIdentityToken));

           IList<Company> companies = criteriaQuery.List<Company>();

           Company company = companies.FirstOrDefault();
           return company;
       }
    }
}
