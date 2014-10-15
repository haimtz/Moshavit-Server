using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.Interfaces;

namespace Moshavit.Service
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly IForgotPasswordMailService _sendMail;
        private readonly IUserService _userService;

        public ForgotPasswordService(IForgotPasswordMailService sendMail, IUserService userService)
        {
            _sendMail = sendMail;
            _userService = userService;
        }

        public void SendPassword(string email)
        {
            var user = _userService.GetUser(email);
            if (user == null)
                return;

            var name = user.FirstName + " " + user.LastName;
            _sendMail.SendMail(name, user.Password, user.Email);
        }
    }
}
