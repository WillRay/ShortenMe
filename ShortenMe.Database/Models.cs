namespace ShortenMe.Database
{
    public record UrlIdentifier(ulong Id, string Identifier);
    public record Location(string Identifier, Uri Uri);
}
