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
   public static class ConjunctionUserMapping
   {
       public static ConjunctionUserView ConvertToConjunctionUserView(this ConjunctionUser conjunctionUser)
       {
           return Mapper.Map<ConjunctionUser, ConjunctionUserView>(conjunctionUser);
       }
    }
}
