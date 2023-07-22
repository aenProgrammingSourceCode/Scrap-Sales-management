using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model
{
   public class GoodsType:EntityBase<int>, IAggregateRoot
    {
        public GoodsType()
        {
           CreatedDate = DateTime.Now.ToString();
        }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        protected override void Validate()
        {
            if (String.IsNullOrEmpty(Name))
                base.AddBrokenRule(GoodsTypeBusinessRules.GoodTypeRequired);
        }
    }
}
