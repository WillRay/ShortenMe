using ShortenMe.Api.Models;

namespace ShortenMe.Api.Services
{
    public sealed class TokenSvc
    {

        public TokenSvc()
        {

        }

        public ulong GetNextIndex()
        {
            return 3;
        }

        public UrlRange GetUrlRage()
        {
            ulong lower = 1;
            ulong upper = 1000;
            return new UrlRange(upper, lower);
        }
    }
}
