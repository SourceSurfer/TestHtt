using Microsoft.Data.SqlClient;
using TestHtt.Models;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestHtt.Services
{
    public class SqlConService
    {
        private string? conStr { get; set; }

        /// <summary>
        /// Устанавливает подключение
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection? Connection()
        {
            /* var config = new ConfigurationBuilder()
                 .AddUserSecrets<Program>()
                 .Build();

             conStr = config["MyConnection"];*/


            var builder = WebApplication.CreateBuilder();

            builder.Services.AddEndpointsApiExplorer();


            var app = builder.Build();
            string conStr = app.Configuration.GetConnectionString("MyConnection")!;

            return new SqlConnection(conStr);
        }

    }
}
