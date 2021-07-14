using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();

        List<Message> GetListSendbox();

        void Add(Message message);

        void Delete(Message message);

        void Update(Message message);

        Message GetById(int id);
    }
}
