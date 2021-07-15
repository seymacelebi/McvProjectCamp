using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAbilityService
    {
       
        void Add(Ability ability);
        void Update(Ability ability);
        void Delete(Ability ability);
        Ability GetById(int id);
        List<Ability> GetList();
    }
}
