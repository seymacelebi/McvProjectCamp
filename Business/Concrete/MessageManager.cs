using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDal.List(x=>x.ReceiverMail== mail);
        }

        public List<Message> GetListSendbox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail);

        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
