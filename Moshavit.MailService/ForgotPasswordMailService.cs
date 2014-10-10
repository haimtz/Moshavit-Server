using System.IO;
using Moshavit.Entity.Interfaces;

namespace Moshavit.MailService
{
    public class ForgotPasswordMailService :IForgotPasswordMailService
    {
        private readonly ISendMail _sendMail;
        public ForgotPasswordMailService(ISendMail sendMail)
        {
            _sendMail = sendMail;
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
            var path = System.AppDomain.CurrentDomain.RelativeSearchPath ?? System.AppDomain.CurrentDomain.BaseDirectory;
            return File.ReadAllText(Path.Combine(path, "forgotmail.html"));
        }

        
    }
}
