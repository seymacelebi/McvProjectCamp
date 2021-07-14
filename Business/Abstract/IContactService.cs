using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();   
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
        Contact GetById(int id);
    }
}
