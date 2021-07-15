using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AbilityManager : IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public void Add(Ability ability)
        {

            _abilityDal.Insert(ability);
        }

        public void Delete(Ability ability)
        {
            _abilityDal.Delete(ability);
        }

        public Ability GetById(int id)
        {
            return _abilityDal.Get(x => x.Id == id);
        }

        public List<Ability> GetList()
        {
            return _abilityDal.List();
        }

        public void Update(Ability ability)
        {
            _abilityDal.Update(ability);
        }
    }
}
