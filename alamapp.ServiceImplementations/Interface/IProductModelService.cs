﻿using alamapp.ServiceImplementations.Messaging.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface IProductModelService
    {
       GetAllProductModelResponse GetAllProductModel();
    }
}
