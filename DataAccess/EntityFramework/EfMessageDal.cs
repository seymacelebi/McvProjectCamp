using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {

    }

}