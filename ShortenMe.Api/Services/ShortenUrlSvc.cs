
using ShortenMe.Database;

namespace ShortenMe.Api.Services
{
    public class ShortenUrlSvc
    {
        private readonly Repository repository;
        private readonly TokenSvc tokenSvc;

        public ShortenUrlSvc(Repository repository, TokenSvc tokenSvc) {
            this.repository = repository;
            this.tokenSvc = tokenSvc;
        }
        public Uri? GetLongUrl(string identifier)
        {
            var result = this.repository.GetLongUrl(identifier);
            return string.IsNullOrEmpty(result) ? (Uri)null : new Uri(result);
        }

        public string CreateShortUrl(Uri longUrl)
        {
            var id = tokenSvc.GetNextIndex();
            var result = repository.CreateShortUrl(id, longUrl);
            return result.Identifier;
        }
    }
}
