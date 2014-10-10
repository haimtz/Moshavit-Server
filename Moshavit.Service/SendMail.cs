using System.Net;
using System.Net.Mail;
using Moshavit.Const;

namespace Moshavit.Service
{
    public class SendMail
    {
        private readonly string _sendEmail;
        private readonly string _subject;
        private readonly string _body;
        private readonly bool _isHtml;

        public SendMail(string sendEmail, string subject, string body, bool isHtml)
        {
            _sendEmail = sendEmail;
            _subject = subject;
            _body = body;
            _isHtml = isHtml;
        }

        public void Send()
        {
            var from = MailAddress(MailConst.From.EMAIL, MailConst.From.DO_NOT_REPLAY);
            var to = MailAddress(_sendEmail);

            using (var message = new MailMessage(from, to))
            {
                message.Subject = _subject;
                message.IsBodyHtml = _isHtml;
                message.Body = _body;

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
