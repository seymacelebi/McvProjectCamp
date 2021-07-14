using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz.");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
        }
    }
}