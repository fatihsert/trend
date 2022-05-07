using Deeplink.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deeplink.Api.Configuration
{
    public class WebUrlConfiguration : IWebUrlConfiguration
    {
        public IList<IDeeplinkValidation> Validations { get; private set; }

        public WebUrlConfiguration()
        {
            this.Validations = new List<IDeeplinkValidation>();
            this.Validations.Add(new EmptyUrlValidation());
            this.Validations.Add(new RegexUrlValidation(@"^ty:\/\/\?Page="));
        }
    }
}
