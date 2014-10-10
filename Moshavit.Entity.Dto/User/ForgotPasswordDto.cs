using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto.User
{
    public class ForgotPasswordDto
    {
        /// <summary>
        /// Email to send password of user
        /// </summary>
        public string Email { get; set; }
    }
}
