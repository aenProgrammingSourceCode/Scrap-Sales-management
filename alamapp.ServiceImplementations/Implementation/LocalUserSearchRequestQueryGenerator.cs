using alamapp.Infrastructure.Querying;
using alamapp.Model;
using alamapp.ServiceImplementations.Messaging.LocalUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class LocalUserSearchRequestQueryGenerator
    {
       public static Query CreateQueryFor()
       {
           Query localUserQuery = new Query();
           
           return localUserQuery;
       }
    }
}
