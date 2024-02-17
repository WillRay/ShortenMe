using ShortenMe.Api.Models;
using ShortenMe.Database;

namespace ShortenMe.Api.Services
{
    public sealed class TokenSvc
    {
        private Stack<ulong> ids;
        private readonly Repository repository;

        public TokenSvc(Repository repository)
        {
            this.repository = repository;
            this.ids = new Stack<ulong>(this.repository.GetAvailableRange(1000));
        }

        public ulong GetNextIndex()
        {
            return ids.Pop();
        }
    }
}
