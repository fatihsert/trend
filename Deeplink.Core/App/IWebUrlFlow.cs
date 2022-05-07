using System;
using System.Collections.Generic;
using System.Text;

namespace Deeplink.Core
{
    public interface IWebUrlFlow
    {
        string Run(string url);
    }
}
