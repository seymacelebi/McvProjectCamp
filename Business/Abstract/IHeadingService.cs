using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetAllByWriter(int id);
        int GetCountByCategory(int categoryID);
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
       
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
