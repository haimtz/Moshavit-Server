using System.IO;
using Moshavit.Const;
using Moshavit.Entity.Interfaces;

namespace Moshavit.MailService
{
    public class ForgotPasswordMailService :IForgotPasswordMailService
    {
        private readonly ISendMail _sendMail;
        private readonly ITemplateService _templateService;
        public ForgotPasswordMailService(ISendMail sendMail, ITemplateService templateService)
        {
            _sendMail = sendMail;
            _templateService = templateService;
        }
        public void SendMail(string username, string password, string email)
        {
            var content = MailContent(username, password);
            _sendMail.Send(email, "You Forgot Your Password", content, true);
        }

        public string MailContent(string username, string password)
        {
            var content = GetHtmlTemplate();
            content = content.Replace("{USER}", username);
            content = content.Replace("{PASSWORD}", password);

            return content;
        }

        private string GetHtmlTemplate()
        {
            return _templateService.EmailContent(MailConst.Template.FORGOT_PASSWORD);
        }
    }
}
