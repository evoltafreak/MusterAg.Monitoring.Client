using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    public class PodRepository : BaseRepository
    {
        public PodRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<Pod> ReadPodList()
        {
            List<Pod> podList = new List<Pod>();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT idPod, description, billLimit, credit FROM POD";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pod pod = new Pod();
                            pod.IdPod = reader.GetInt64(0);
                            pod.Description = reader.GetString(1);
                            pod.BillLimit = reader.GetDecimal(2);
                            pod.Credit = reader.GetDecimal(3);
                            podList.Add(pod);
                        }
                    }
                }
            }

            return podList;
        }
        
    }
}