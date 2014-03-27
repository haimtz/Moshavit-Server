using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Exceptions
{
    public class  RegistrationException : Exception
    {
        public RegistrationException() {}

        public RegistrationException(string message) : base(message) {}
    }
}
