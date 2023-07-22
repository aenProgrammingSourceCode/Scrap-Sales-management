using alamapp.Model;
using alamapp.ServiceImplementations.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class LocalUserMapping
    {
       public static LocalUserView ConvertToLocalUserView(this LocalUser localUser)
       {
           return Mapper.Map<LocalUser, LocalUserView>(localUser);
       }
    }
}
