using Npgsql;

namespace ShortenMe.Database
{
    public sealed class Repository
    {
        private readonly string connectionString;

        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UrlIdentifier CreateShortUrl(ulong id, Uri url)
        {
            using (var connection = new NpgsqlConnection(this.connectionString))
            using (var cmd = new NpgsqlCommand(this.connectionString))
            {
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT url_identifier FROM urlidentifiers WHERE id = {id}";
                cmd.Connection.Open();
                var result = cmd.ExecuteScalar().ToString();

                cmd.CommandText = $"INSERT INTO locations (url_identifier, uri) VALUES ('{result}', '{url}')";
                cmd.ExecuteNonQuery();
                return new UrlIdentifier(id, result);
            }
        }

        public IEnumerable<ulong> GetAvailableRange(int amount)
        {
            using (var connection = new NpgsqlConnection(this.connectionString))
            using (var cmd = new NpgsqlCommand(this.connectionString))
            {
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT id " +
                    "FROM urlidentifiers " +
                    "LEFT JOIN locations ON urlidentifiers.url_identifier = locations.url_identifier " +
                    "WHERE locations.url_identifier IS NULL " +
                    $"FETCH FIRST {amount} ROWS ONLY";

                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                var results = new List<ulong>();

                while (reader.Read())
                {
                    results.Add(Convert.ToUInt64(reader["id"]));
                }

                return results;
            }
        }

        public string GetLongUrl(string identifier)
        {
            using (var connection = new NpgsqlConnection(this.connectionString))
            using (var cmd = new NpgsqlCommand(this.connectionString))
            {
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT uri " +
                    "FROM locations " +
                    $"WHERE url_identifier = '{identifier}'";

                cmd.Connection.Open();
                var result = cmd.ExecuteScalar();

                return Convert.ToString(result);
            }
        }
    }
}
