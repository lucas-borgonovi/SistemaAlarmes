using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio.Services
{
    public class EquipDatabase
    {
        private static SQLiteConnection _sqliteConnection;

        private readonly ILogger _logger;

        public EquipDatabase()
        {

        }

        private static SQLiteConnection DbConnection()
        {
            var path = Directory.GetCurrentDirectory() + @"\Database\db.db; Version=3;";
            _sqliteConnection = new SQLiteConnection(@"Data Source=" + path);
            _sqliteConnection.Open();
            return _sqliteConnection;
        }

        public async Task<int> CreateEquipTable()
        {

            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Equipamentos(id INTEGER PRIMARY KEY AUTOINCREMENT , Nome Varchar(255), NumeroSerie Varchar(255), Tipo Varchar(255), Data Varchar(255))";
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result;

                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método CreateEquipTable de EquipDatabase", ex);
                return 0;
            }
        }

        public async Task<int> InsertEquipData(Equipamentos equip)
        {
            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "INSERT INTO Equipamentos(Nome,NumeroSerie,Tipo,Data) Values(@Nome,@NumeroSerie,@Tipo,@Data)";
                    con.Parameters.AddWithValue("@Nome", equip.Nome);
                    con.Parameters.AddWithValue("@NumeroSerie", equip.NumeroSerie);
                    con.Parameters.AddWithValue("@Tipo", equip.Tipo);
                    con.Parameters.AddWithValue("@Data", equip.Data);
                    var result = await con.ExecuteNonQueryAsync();
                    return result;
                }

            }
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método InsertEquipData de EquiDatabase", ex);
                return 0;
            }
        }

        public DataTable GetAllEquipsNames()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "SELECT id,nome FROM Equipamentos";
                    da = new SQLiteDataAdapter(con.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;

                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método GetAllEquiNames de EquipDatabase", ex);
                return null;
            }
        }



    }
}
