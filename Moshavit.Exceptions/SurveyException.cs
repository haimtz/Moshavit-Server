using System;

namespace Moshavit.Exceptions
{
    public class SurveyException : Exception
    {
        public SurveyException() { }

        public SurveyException(string message) : base(message) { }
    }
}
