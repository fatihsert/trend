using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deeplink.Core;

namespace Deeplink.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebUrlController : Controller
    {
        private readonly IWebUrlFlow webUrlFlow;

        public WebUrlController(IWebUrlFlow webUrlFlow)
        {
            this.webUrlFlow = webUrlFlow;
        }
        /// <summary>
        /// Converts Deeplink to Web Url
        /// </summary>
        /// <param name="deeplink">Deeplink</param>
        /// <returns>A deeplink</returns>
        /// <response code="200">Returns the converted Web url</response>
        /// <response code="400">If the deeplink is null</response>  
        [HttpGet]
        public string ConvertToWebUrl(string deeplink)
        {
            return webUrlFlow.Run(deeplink);
        }
    }
}
