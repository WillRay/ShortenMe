
namespace ShortenMe.Api.Services
{
    public class ShortenUrlSvc
    {
        internal Uri Shorten(Uri longUrl)
        {
            // get current available id
            // call db to get shorten option
            // insert new shorten record
            // increment id
            // return result

            return new Uri("http://www.google.com/");
        }

        internal Uri Create(Uri longUrl)
        {
            return new Uri("http://www.google.com/12345");
        }
    }
}
