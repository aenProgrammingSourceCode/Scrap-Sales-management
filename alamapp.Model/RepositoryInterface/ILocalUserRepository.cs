﻿using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface
{
   public interface ILocalUserRepository:IRepository<LocalUser,int>
    {
       LocalUser FindBy(string userIdentityToken);
    }
}
