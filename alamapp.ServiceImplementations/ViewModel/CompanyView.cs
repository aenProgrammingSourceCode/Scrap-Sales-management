using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel
{
   public class CompanyView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        public int CountBid { get; set; }
    }
}
