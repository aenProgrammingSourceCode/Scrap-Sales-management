using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Querying
{
   public class Query
    {
       private  IList<Query> _subQueries=new List<Query>();
       private  IList<Criterion> _criteria=new List<Criterion>();

       public IEnumerable<Query> SubQueries
       {
           get { return _subQueries; }
       }

       public IEnumerable<Criterion> Criteria
       {
           get { return _criteria; }
       }

       public void AddSubQueries(Query subQueries)
       {
           _subQueries.Add(subQueries);
       }

       public void Add(Criterion criteria)
       {
           _criteria.Add(criteria);
       }

       public OrderByClause OrderByProperty { get; set; }
       public QueryOperator QueryOperator { get; set; }
    }
}
