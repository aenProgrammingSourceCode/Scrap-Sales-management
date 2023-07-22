using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Categories
{
   public class Category:EntityBase<int>, IAggregateRoot
    {
        public Category()
        {
           CreatedDate = DateTime.Now;
        }
        private DateTime _createdDate;

        public DateTime CreatedDate
        {
           get { return _createdDate; }
           set { _createdDate = value; }
        }
        public string Name { get; set; }
        public string ImageId { get; set; }
        public string Description { get; set; }
        protected override void Validate()
        {
           if(string.IsNullOrEmpty(Name))
           {
               base.AddBrokenRule(CategoryBusinessRule.CategoryNameRequired);
           }
           if (string.IsNullOrEmpty(ImageId))
           {
               base.AddBrokenRule(CategoryBusinessRule.CategoryDescritpionRequired);
           }
        }
    }
}
