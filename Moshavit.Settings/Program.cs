using System;
using System.IO;
using Moshavit.Castel;
using Moshavit.Const;
using Moshavit.Entity;
using Moshavit.Entity.Interfaces;
using Moshavit.MailService;

namespace Moshavit.Settings
{
    class Program
    {
        private static IDependency _resolver;
        static void Main(string[] args)
        {
            _resolver = new CastleFactory();
            LoadTemplateMail();
        }

        private static void LoadTemplateMail()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "forgotmail.html");
            var content = File.ReadAllText(path);

            var emailTemplate = new EmailTemplate
            {
                Name = MailConst.Template.FORGOT_PASSWORD,
                Content = content
            };

            var service = _resolver.Resolver<ITemplateService>();
            
            service.AddTempalte(emailTemplate);
        }
    }
}
