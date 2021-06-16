using Exercicio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AlarmDatabase
    {
        private static SQLiteConnection _sqliteConnection;

        private readonly ILogger _logger;

        public AlarmDatabase()
        {
        }

        private static SQLiteConnection DbConnection()
        {
            var path = Directory.GetCurrentDirectory() + @"\Database\db.db; Version=3;";
            _sqliteConnection = new SQLiteConnection(@"Data Source=" + path);
            _sqliteConnection.Open();
            return _sqliteConnection;
        }

        public async Task<int> CreateAlarmeTable()
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
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método CreateAlarmTable de Alarm Database", ex);
                return 0;
            }
        }

        public async  Task<int> InsertAlarmData(Alarmes alarm)
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
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método InsertAlarmData de AlarmDatabase", ex);
                return 0;
            }
        }

        public  DataTable GetAllAlarms()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var con = DbConnection().CreateCommand())
                {
                    con.CommandText = "select al.id,al.Descricao,al.Classificacao,al.Data,al.Status,eq.Nome from Alarmes as al, Equipamentos as eq where al.EquipId = eq.id";
                    da = new SQLiteDataAdapter(con.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;

                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método GetAllAlarms de AlarmDatabase", ex);
                return null;
            }
        }

        public async Task<int> UpdateAlarms(int id, Alarmes alarm)
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
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método GetAllEquipments de Equipamentos Controller", ex);
                return 0;
            }
        }

    }
}
