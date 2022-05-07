using System;

namespace Deeplink.Core
{
    public class NotFoundDeeplinkServiceException : ArgumentException
    {
        public NotFoundDeeplinkServiceException() : base("Deeplink service not found")
        {

        }
    }
}
