using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() { }

        public LoginException(string message) : base(message) { }
    }
}
