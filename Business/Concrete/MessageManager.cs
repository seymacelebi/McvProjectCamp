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

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x=>x.ReceiverMail== "asli.kaya@gmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "asli.kaya@gmail.com");

        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
