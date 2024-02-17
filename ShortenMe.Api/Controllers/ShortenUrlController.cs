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
        public Uri Get(Uri longUrl)
        {
            var result = shortenUrlSvc.Shorten(longUrl);
            return result;
        }

        [HttpPost]
        public Uri Post(Uri longUrl)
        {
            var result = shortenUrlSvc.Create(longUrl);
            return result;
        }
    }
}
