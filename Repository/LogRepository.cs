using System.Collections.Generic;
using System.Data;
using MusterAg.Monitoring.Client.Model;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LogRepository
    {
        public List<Log> ReadLogList(string connectionString)
        {
            List<Log> logList = new List<Log>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, pod, location, hostname, severity, timestamp, message FROM v_logentries ORDER BY timestamp";
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

        public void ClearLog(string connectionString, long id, List<Log> logList)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                foreach (Log log in logList)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "LogClear";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        
        private Log FillLog(MySqlDataReader reader)
        {
            return new Log()
            {
                Id = reader.GetInt64(0),
                Pod = reader.GetString(1),
                Location = reader.GetString(2),
                Hostname = reader.GetString(3),
                // TODO: use enum
                Severity = Severity.INFO, //Enum.Parse(typeof(Severity), reader.GetString(4).ToString()),
                Timestamp = reader.GetDateTime(5),
                Message = reader.GetString(6)
            };
        }
        
    }
}