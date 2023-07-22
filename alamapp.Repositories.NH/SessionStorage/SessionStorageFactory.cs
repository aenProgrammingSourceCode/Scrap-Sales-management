﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace alamapp.Repositories.NH.SessionStorage
{
   public class SessionStorageFactory
    {
       private static ISessionStorageContainer _sessionStorageContainer;

       public static ISessionStorageContainer GetStorageContainer()
       {
           if(_sessionStorageContainer==null)
           {
               if(HttpContext.Current==null)
               _sessionStorageContainer = new ThreadSessionStorageContainer();
               else
                   _sessionStorageContainer = new HttpSessionContainer();
           }
           return _sessionStorageContainer;
       }

    }
}
