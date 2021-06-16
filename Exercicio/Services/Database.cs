using Exercicio.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio.Controllers
{
    public class Database
    {
        private static SQLiteConnection _sqliteConnection;

        private readonly ILogger _logger;

        public Database()
        {

        }


        private static SQLiteConnection DbConnection()
        {
            var path = Directory.GetCurrentDirectory() + @"\Database\db.db";
            _sqliteConnection = new SQLiteConnection(@"Data Source=" + path);
            _sqliteConnection.Open();
            return _sqliteConnection;
        }

        public string CreateDatabase()
        {
            try
            {
                var path = Directory.GetCurrentDirectory() + @"\Database\db.db";
                SQLiteConnection.CreateFile(path);
                return "Sucesso";
            }
            catch(Exception ex)
            {
                //_logger.LogError("Erro ao criar o banco de dados", ex);
                return ex.Message;
            }
        }

    }
}
