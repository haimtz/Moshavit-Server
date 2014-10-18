using System;

namespace Moshavit.Exceptions
{
    public class VoteException : Exception
    {
        public VoteException()
        {
        }

        public VoteException(string message) : base(message)
        {
        }
    }
}
