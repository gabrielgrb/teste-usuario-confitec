using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Teste.Confitec.Infra.Data
{
    public class Startup
    {
        public static void RunMigration<T>(IApplicationBuilder app) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                CreateDatabaseIfNotExists(context);
                context.Database.Migrate();
            }
        }

        private static void CreateDatabaseIfNotExists<T>(T context) where T : DbContext
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(context.Database.GetDbConnection().ConnectionString);
            string connectionString = context.Database.GetDbConnection().ConnectionString.Replace(connectionStringBuilder.InitialCatalog, "master");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string script = string.Format(@"
                    IF  NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'{0}')
                        CREATE DATABASE [{0}] COLLATE Latin1_General_CI_AI;", connectionStringBuilder.InitialCatalog);

                SqlCommand command = new SqlCommand(script, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
