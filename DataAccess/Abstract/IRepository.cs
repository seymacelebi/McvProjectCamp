using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T p);

        void Delete(T p);

        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
