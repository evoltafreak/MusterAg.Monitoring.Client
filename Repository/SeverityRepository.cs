using System;
using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    public class SeverityRepository : BaseRepository
    {
        public SeverityRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<Severity> ReadSeverityList()
        {
            List<Severity> severityList = new List<Severity>();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "SELECT severity FROM SEVERITY";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            severityList.Add((Severity)Enum.Parse(typeof(Severity), reader.GetString(0)));
                        }
                    }
                }
            }

            return severityList;
        }
        
    }
}