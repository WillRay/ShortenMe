using Microsoft.AspNetCore.Mvc;
using ShortenMe.Api.Services;

namespace ShortenMe.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ShortenUrlController : ControllerBase
    {
        private readonly ShortenUrlSvc shortenUrlSvc;

        public ShortenUrlController(ShortenUrlSvc shortenUrlSvc)
        {
            this.shortenUrlSvc = shortenUrlSvc;
        }

        [HttpGet]
        public ActionResult<Uri> Get(string identifier)
        {
            var result = shortenUrlSvc.GetLongUrl(identifier);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public string Post(Uri longUrl)
        {
            var result = shortenUrlSvc.CreateShortUrl(longUrl);
            return result;
        }
    }
}
