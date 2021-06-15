using Exercicio.Models;
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
        private static SQLiteConnection sqliteConnection;

        public Database()
        {

        }


        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection(@"Data Source=C:\Users\EW4559\OneDrive - SKF\Desktop\faculdade\CRUD\Exercicio\Database\dbteste.db; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CreateDatabase()
        {
            try
            {
                var path = Directory.GetCurrentDirectory() + @"\Database\dbteste.db";
                SQLiteConnection.CreateFile(path);
            }
            catch
            {
                throw;
            }
        }

        public async static Task<int> CreateEquipTable()
        {

            try
            {
                using(var cmd =DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Equipamentos(id INTEGER PRIMARY KEY AUTOINCREMENT , Nome Varchar(255), NumeroSerie Varchar(255), Tipo Varchar(255), Data Varchar(255))";
                    var result = await cmd.ExecuteNonQueryAsync();

                    return result;

                }
            }
            catch
            {
                throw;
            }
        }
        public async static Task<int> CreateAlarmeTable()
        {

            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "CREATE TABLE IF NOT EXISTS Alarmes(id INTEGER PRIMARY KEY AUTOINCREMENT, Descricao Varchar(255), Classificacao Varchar(255), EquipId int, Data Varchar(255),Status Boolean, Foreign key (EquipID) references Equipamentos(id))";
                    var result = await con.ExecuteNonQueryAsync();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async static Task<int> InsertEquipData(Equipamentos equip)
        {
            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "INSERT INTO Equipamentos(Nome,NumeroSerie,Tipo,Data) Values(@Nome,@NumeroSerie,@Tipo,@Data)";
                    con.Parameters.AddWithValue("@Nome",equip.Nome);
                    con.Parameters.AddWithValue("@NumeroSerie", equip.NumeroSerie);
                    con.Parameters.AddWithValue("@Tipo", equip.Tipo);
                    con.Parameters.AddWithValue("@Data", equip.Data);
                    var result = await con.ExecuteNonQueryAsync();
                    return result;
                }
                
            }
            catch
            {
                throw;
            }
        }
        public async static Task<int> InsertAlarmData(Alarmes alarm)
        {
            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "INSERT INTO Alarmes(Descricao,Classificacao,EquipId,Data,Status) Values(@Descricao,@Classificacao,@EquipId,@Data,@Status)";
                    con.Parameters.AddWithValue("@Descricao", alarm.Descricao);
                    con.Parameters.AddWithValue("@Classificacao", alarm.Classificacao);
                    con.Parameters.AddWithValue("@EquipId", alarm.EquipRelacionado);
                    con.Parameters.AddWithValue("@Data", alarm.Data);
                    con.Parameters.AddWithValue("@Status", alarm.Status);
                    var result = await con.ExecuteNonQueryAsync();
                    return result;
                }

            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetAllEquipsNames()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using(var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "SELECT id,nome FROM Equipamentos";
                    da = new SQLiteDataAdapter(con.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;

                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetAllAlarms()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "select al.id,al.Descricao,al.Classificacao,al.Data,al.Status,eq.Nome from Alarmes as al, Equipamentos as eq where al.id = eq.id";
                    da = new SQLiteDataAdapter(con.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;

                }
            }
            catch
            {
                throw;
            }
        }
        public async static Task<int> UpdateAlarms(int id,Alarmes alarm)
        {

            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "UPDATE Alarmes SET Status = @Status WHERE id = @ID;";
                    con.Parameters.AddWithValue("@Status", alarm.Status);
                    con.Parameters.AddWithValue("@ID", id);

                    var result = await con.ExecuteNonQueryAsync();
                    return result;

                }
            }
            catch
            {
                throw;
            }
        }


    }
}
