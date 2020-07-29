using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using MusterAg.Monitoring.Client.Models;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LogEFRepository
    {

        public List<VLogentries> ReadLogList()
        {
            using (var ctx = new musteragContext())
            {
                return ctx.VLogentries.ToList();
            }
        }
        
        public void ClearLog(long id)
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringSqlServer"].ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "musterag.LogClear";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public void AddLog(VLogentries log)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringSqlServer"].ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "musterag.LogMessageAdd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPod", log.Id);
                    cmd.Parameters.AddWithValue("@IdSeverity", 1);
                    cmd.Parameters.AddWithValue("@Message", log.Message);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}