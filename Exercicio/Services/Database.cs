//using Exercicio.Models;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SQLite;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Exercicio.Controllers
//{
//    public class Database
//    {
//        private static SQLiteConnection _sqliteConnection;



//        public Database()
//        {

//        }


//        private static SQLiteConnection DbConnection()
//        {
//            var path = Directory.GetCurrentDirectory() + @"\Database\db.db";
//            _sqliteConnection = new SQLiteConnection(@"Data Source=" + path);
//            _sqliteConnection.Open();
//            return _sqliteConnection;
//        }

//        public void CreateDatabase()
//        {
//            try
//            {
                
                
//            }
//            catch
//            {
//                throw;
//            }
//        }

//    }
//}
