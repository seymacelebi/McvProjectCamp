using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: WriterPanelMessage

        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = messageManager.GetListSendbox();
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult validationResult = messageValidator.Validate(p);
            if (validationResult.IsValid)
            {
                p.SenderMail = "asli.kaya@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}