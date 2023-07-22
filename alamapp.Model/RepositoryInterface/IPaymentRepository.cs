﻿using alamapp.Infrastructure.Domain;
using alamapp.Model.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface
{
   public interface IPaymentRepository:IRepository<Payment,string>
    {
    }
}
