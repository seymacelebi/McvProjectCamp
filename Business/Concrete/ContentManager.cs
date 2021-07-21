using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void Add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetById(Content content)
        {
            throw new System.NotImplementedException();
        }

        public int GetnumberByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id).Count;
        }

        public List<Content> GetList(string p)
        {
            if (p == null)
            {
                return _contentDal.List();
            }
            return _contentDal.List(x => x.ContentValue.Contains(p));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListById(int id)
        {
            return _contentDal.List(h => h.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public void Update(Content content)
        {
            throw new System.NotImplementedException();
        }
    }
}
