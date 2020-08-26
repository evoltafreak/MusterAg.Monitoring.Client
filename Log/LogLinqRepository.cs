using System.Collections.Generic;
using System.Data;
using System.Linq;
using LinqToDB;
using MusterAg.Monitoring.Client.Model;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LogLinqRepository : BaseLinqRepository<Log>
    {
        public LogLinqRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Log> ReadLogList()
        {
            List<Log> logList = new List<Log>();
            using (var ctx = new DataContext("MusterAgDb")) {

                ITable<LogEntity> podTable = ctx.GetTable<LogEntity>();
                IQueryable<LogEntity> query = podTable;
                foreach (LogEntity logEntity in query) {
                    Log pod = new Log(logEntity);
                    logList.Add(pod);
                }
     
            }
            return logList;
        }

        /**
         * Executes stored procedure without using LINQ. See https://github.com/linq2db/linq2db/issues/1987
         */
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

        /**
         * Executes stored procedure without using LINQ. See https://github.com/linq2db/linq2db/issues/1987
         */
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