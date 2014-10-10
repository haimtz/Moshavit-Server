using System.Net;
using System.Net.Mail;
using Moshavit.Const;
using Moshavit.Entity.Interfaces;

namespace Moshavit.Service
{
    public class SendMail : ISendMail
    {
        public void Send(string sendEmail, string subject, string body, bool isHtml)
        {
            var from = MailAddress(MailConst.From.EMAIL, MailConst.From.DO_NOT_REPLAY);
            var to = MailAddress(sendEmail);

            using (var message = new MailMessage(from, to))
            {
                message.Subject = subject;
                message.IsBodyHtml = isHtml;
                message.Body = body;

                Smtp.Send(message);
            }

        }

        private MailAddress MailAddress(string email, string from = null)
        {
            return new MailAddress(email, from);
        }

        private SmtpClient Smtp
        {
            get
            {
                return new SmtpClient
                {
                    Host = MailConst.Account.HOST,
                    Port = MailConst.Account.PORT,
                    Credentials = new NetworkCredential(MailConst.Account.MAIL_ACCOUNT, MailConst.Account.PASSWORD),
                    EnableSsl = true
                };
            }
        }
    }
}
