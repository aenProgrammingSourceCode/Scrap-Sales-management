using alamapp.ServiceImplementations.Messaging.Authentications;
using alamapp.ServiceImplementations.Messaging.LocalUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
    public interface ILocalUserService
    {
        void CreateLocalUser(CreateLocalUserRequest request);
        GetLocalUserResponse GetLocalUser(GetLocalUserRequest request);
        GetConjunctionUserResponse GetConjunctionUser(GetConjunctionUserRequest request);
        int GetConjunctionId(GetConjunctionUserRequest request);
        void CreateConjunction(CreateConjunctionUserRequest request);
    }
}
