using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfTalentDal : GenericRepository<Talent>, ITalentDal
    {
    }
}
