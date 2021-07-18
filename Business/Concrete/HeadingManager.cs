using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetAll()
        {
            return _headingDal.List();
        }

        public List<Heading> GetAllByWriter()
        {
            return _headingDal.List(x => x.WriterId ==4);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(h => h.HeadingId == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
          
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
