using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace WebApplicationAPIRestDemo.Persistence
{
    public class DbContext
    {
        public static MySqlConnection GetInstance()
        {
            var configuration = GetConfiguration();

            // obtenim la cadena de connexió del fitxer de configuració
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("MySQL").Value;

            var db = new MySqlConnection(connectionString);

            db.Open();

            return db;
        }

        /// <summary>
        /// Per agafar les dades del fitxer appsettings.json
        /// </summary>
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
