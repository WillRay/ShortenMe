using DbUp;
using System.Reflection;

namespace ShortenMe.Database
{
    public static class Program
    {
        public static void Main()
        {
            var connectionString = "";
            RunMigrations(connectionString);
        }

        public static void RunMigrations(string connectionString)
        {
            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var result = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsAndCodeEmbeddedInAssembly(
                    Assembly.GetAssembly(typeof(Program)))
                .LogToConsole()
                .LogScriptOutput()
                .Build();

            result.PerformUpgrade();
        }
    }
}