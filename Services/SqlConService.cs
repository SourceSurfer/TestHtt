using Microsoft.Data.SqlClient;

namespace TestHtt.Services
{
    public class SqlConService
    {

        /// <summary>
        /// Устанавливает подключение
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection? Connection()
        {
          
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            string conStr = app.Configuration.GetConnectionString("MyConnection")!;

          
            return new SqlConnection(conStr);
        }

    }
}
