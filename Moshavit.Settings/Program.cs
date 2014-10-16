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
            Console.WriteLine("Start run settings.....");
            _resolver = new CastleFactory();
            LoadTemplateMail();

            Console.WriteLine("Finish settings");
            Console.ReadLine();
        }

        private static void LoadTemplateMail()
        {
            Console.WriteLine("Load Forgot password email template....");
            var service = _resolver.Resolver<ITemplateService>();
            var path = Path.Combine(Environment.CurrentDirectory, "forgotmail.html");
            var content = File.ReadAllText(path);

            var emaiTemplate = new EmailTemplate
            {
                Name = MailConst.Template.FORGOT_PASSWORD,
                Content = content
            };

            service.AddTempalte(emaiTemplate);

            Console.WriteLine("Load welcome email template....");
            path = Path.Combine(Environment.CurrentDirectory, "welcomemail.html");
            content = File.ReadAllText(path);

            emaiTemplate.Name = MailConst.Template.WELCOM_MAIL;
            emaiTemplate.Content = content;

            service.AddTempalte(emaiTemplate);
        }
    }
}
