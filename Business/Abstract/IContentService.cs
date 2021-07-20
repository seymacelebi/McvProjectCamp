using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
     public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        List<Content> GetListById(int id);
        List<Content> GetListByHeadingId(int id);
        void  Add(Content content);
        void  Delete(Content content);
        void  Update(Content content);
        Content GetById(Content content);
        
    }
}
