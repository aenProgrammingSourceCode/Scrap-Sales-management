﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel
{
   public class LocalUserView
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string UserIdentityToken { get; set; }
    }
}
