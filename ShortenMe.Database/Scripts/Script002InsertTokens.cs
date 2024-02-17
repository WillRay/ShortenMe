using DbUp.Engine;
using System.Data;

namespace ShortenMe.Database.Scripts
{
    internal class Script002InsertTokens : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            using (var command = dbCommandFactory())
            {
                var text = Enumerable.Range(1, 10001)
                    .Select(BuildIdentifer);

                var commandText = string.Join(", ", text);

                command.CommandText = $"INSERT INTO urlidentifiers(id, url_identifier) VALUES {commandText}";
                command.ExecuteNonQuery();
            }

            return string.Empty;
        }

        private string BuildIdentifer(int i)
        {
            var urlIdentifer = i.ToString("X");

            if (urlIdentifer.Length < 3)
            {
                var pad = 3 - urlIdentifer.Length;
                urlIdentifer = urlIdentifer.PadLeft(pad, '0');
            }

            return $"({i}, '{urlIdentifer}')";
        }
    }
}
