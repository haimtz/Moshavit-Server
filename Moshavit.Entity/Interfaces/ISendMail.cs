using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Interfaces
{
    public interface ISendMail
    {
        /// <summary>
        /// Send mail
        /// </summary>
        void Send(string sendEmail, string subject, string body, bool isHtml);
    }
}
