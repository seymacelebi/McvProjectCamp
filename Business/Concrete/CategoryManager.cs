using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" || p.CategoryName.Length <= 3 ||
                p.CategoryDescription == "" || p.CategoryName.Length >= 51)
            {
                // hata
            }
            else
            {
                repo.Insert(p);
            }
        }
    }
}