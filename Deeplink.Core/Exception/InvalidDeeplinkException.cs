using System;

namespace Deeplink.Core
{
    public class InvalidDeeplinkException : ArgumentException
    {
        public InvalidDeeplinkException() : base("Invalid url")
        {

        }
    }
}
