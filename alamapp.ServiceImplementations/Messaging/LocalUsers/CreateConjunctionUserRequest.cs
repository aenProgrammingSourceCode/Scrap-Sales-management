using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.LocalUsers
{
   public class CreateConjunctionUserRequest
    {
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public int BlockId { get; set; }
    }
}
