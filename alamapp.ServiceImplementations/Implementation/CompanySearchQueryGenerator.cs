using alamapp.Infrastructure.Querying;
using alamapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public static class CompanySearchQueryGenerator
    {
       public static Query CreateComapnyForQuery(string userIdentity)
       {
           Query bidQuery = new Query();
           Query productModelQuery = new Query();
           Query goodsTypeQuery = new Query();

           productModelQuery.Add(Criterion.Create<Company>(b => b.AspUser.Id, userIdentity, CriteriaOperator.Equel));

           return productModelQuery;
       }
    }
}
