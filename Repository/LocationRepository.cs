using System.Collections.Generic;
using MusterAg.Monitoring.Client.Model;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LocationRepository : BaseRepository<Location>
    {
        
        public LocationRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        public List<Location> ReadAllLocationList()
        {
            List<Location> locationList = new List<Location>();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Location";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Location location = new Location();
                            location.IdLocation = reader.GetInt64(0);
                            location.Address = reader.GetString(1);
                            location.AddressNr = reader.GetString(2);
                            location.FidPlace = reader.GetInt64(3);
                            locationList.Add(location);
                        }
                    }
                }
            }

            return locationList;
        }
        
        public override string TableName => "Location";
    }
}