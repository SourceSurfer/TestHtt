﻿using Microsoft.Data.SqlClient;
using TestHtt.Models;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestHtt.Services
{
    public class SqlConService
    {
        private string connectionString { get; set; }

        /// <summary>
        /// Устанавливает подключение
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection? Connection()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            connectionString = config["MyConnection"];

            using (SqlConnection? connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return connection;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }

    }
}