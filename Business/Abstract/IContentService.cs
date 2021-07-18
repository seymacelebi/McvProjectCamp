using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
     public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByWriter();
        List<Content> GetListById(int id);
        void  Add(Content content);
        void  Delete(Content content);
        void  Update(Content content);
        Content GetById(Content content);
        
    }
}
