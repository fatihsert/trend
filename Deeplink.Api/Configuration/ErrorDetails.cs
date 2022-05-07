using System;

namespace Deeplink.Api.Configuration
{
    [Serializable]
    public class ErrorDetails
    {
        public ErrorDetails()
        {
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}