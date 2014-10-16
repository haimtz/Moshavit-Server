using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Const;
using Moshavit.Entity.Interfaces;

namespace Moshavit.MailService
{
    public class WelcomeMailService : IWelcomeMailService
    {
        private readonly ISendMail _mailService;
        private readonly ITemplateService _templateService;

        public WelcomeMailService(ISendMail mailService, ITemplateService templateService)
        {
            _mailService = mailService;
            _templateService = templateService;
        }

        public void SendWelcome(string email, string username)
        {
            var content = MailContent();
            content = content.Replace("{USER}", username);
            _mailService.Send(email, MailConst.From.DO_NOT_REPLAY, content, true);
        }

        private string MailContent()
        {
            return _templateService.EmailContent(MailConst.Template.WELCOM_MAIL);
        }
    }
}
