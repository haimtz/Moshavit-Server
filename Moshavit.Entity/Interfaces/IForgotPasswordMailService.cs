using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Interfaces
{
    public interface IForgotPasswordMailService
    {
        void SendMail(string username, string password, string email);
    }
}
