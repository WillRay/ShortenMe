using Microsoft.AspNetCore.Mvc;
using ShortenMe.Api.Services;

namespace ShortenMe.Api.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedirectController : Controller
    {
        private readonly ShortenUrlSvc shortenUrlSvc;

        public RedirectController(ShortenUrlSvc shortenUrlSvc)
        {
            this.shortenUrlSvc = shortenUrlSvc;
        }

        [Route("{*queryvalues}")]
        public IActionResult Index(string queryvalues)
        {
            if (string.IsNullOrEmpty(queryvalues))
            {
                return NotFound();
            }

            var result = shortenUrlSvc.GetLongUrl(queryvalues);
            if (result == null)
            {
                return NotFound();
            }

            return Redirect(result.ToString());
        }
    }
}
