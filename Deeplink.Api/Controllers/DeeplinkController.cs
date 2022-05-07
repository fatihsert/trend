using Deeplink.Core;
using Microsoft.AspNetCore.Mvc;

namespace Deeplink.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeeplinkController : Controller
    {
        private readonly IDeeplinkFlow deeplinkFlow;

        public DeeplinkController(IDeeplinkFlow deeplinkFlow)
        {
            this.deeplinkFlow = deeplinkFlow;
        }

        /// <summary>
        /// Converts web URLs to deeplink
        /// </summary>
        /// <param name="url">Web URL</param>
        /// <returns>A deeplink</returns>
        /// <response code="200">Returns the converted deeplink</response>
        /// <response code="400">If the url is null</response>  
        [HttpGet]
        public string ConvertToDeeplink(string url)
        {
            return deeplinkFlow.Run(url);
        }
    }
}
