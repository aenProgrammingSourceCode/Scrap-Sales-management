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
    public static class CompanyMapping
    {
        public static CompanyView ConvertToCompanyView(this Company company)
        {
            return Mapper.Map<Company, CompanyView>(company);
        }

        public static IEnumerable<CompanyView> ConvertToCompanyViews(this IEnumerable<Company> Companies)
        {
            return Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyView>>(Companies);
        }
    }
}
