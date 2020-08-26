using System;
using System.Collections.Generic;
using System.Data;
using MusterAg.Monitoring.Client.Model;
using MusterAg.Monitoring.Client.Models;
using MySql.Data.MySqlClient;
using Severity = MusterAg.Monitoring.Client.Model.Severity;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LogRepository : BaseRepository<Log>
    {
        public LogRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<Log> ReadLogList()
        {
            List<Log> logList = new List<Log>();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "SELECT id, pod, location, hostname, severity, timestamp, message FROM v_logentries ORDER BY timestamp";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Log log = FillLog(reader);
                            logList.Add(log);
                        }
                    }
                }
            }

            return logList;
        }

        public void ClearLog(long id)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "LogClear";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Log FillLog(MySqlDataReader reader)
        {
            return new Log()
            {
                IdPod = reader.GetInt64(0),
                Pod = reader.GetString(1),
                Location = reader.GetString(2),
                Hostname = reader.GetString(3),
                Severity = (Severity)Enum.Parse(typeof(Severity), reader.GetString(4)),
                Timestamp = reader.GetDateTime(5),
                Message = reader.GetString(6)
            };
        }

        public void AddLog(Log log)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "LogMessageAdd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPod", log.IdPod);
                    cmd.Parameters.AddWithValue("@IdSeverity", log.Severity);
                    cmd.Parameters.AddWithValue("@Message", log.Message);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public override string TableName => "Log";
        
    }
}