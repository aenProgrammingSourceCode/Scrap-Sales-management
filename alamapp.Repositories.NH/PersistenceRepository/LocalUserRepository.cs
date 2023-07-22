using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model;
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
   public class LocalUserRepository:Repository<LocalUser,int>, ILocalUserRepository
    {
       public LocalUserRepository(IUnitOfWork uow):
           base(uow)
       {

       }
       public LocalUser FindBy(string userIdentityToken)
       {
           ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                    .CreateCriteria(typeof(LocalUser))
                    .Add(Expression.Eq(PropertyNameHelper
                    .ResolvePropertyName<LocalUser>
                   (c => c.UserIdentityToken), userIdentityToken));

           IList<LocalUser> companies = criteriaQuery.List<LocalUser>();

           LocalUser company = companies.FirstOrDefault();
           return company;
       }
    }
}
