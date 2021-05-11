﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager (ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public List<Category> GetList()
        {
            //generic repository newlemeden erişim sağladım.
            return _categoryDal.List();
        }
        //public void CategoryAddBL(Category p)
        //{
        //    if(p.CategoryName=="" || p.CategoryStatus==false ||
        //        p.CategoryName.Length <= 2)
        //    {

        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //}
    }
}