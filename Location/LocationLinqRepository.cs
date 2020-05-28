using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using MusterAg.Monitoring.Client.Model;

namespace MusterAg.Monitoring.Client.Repository
{
    public class LocationLinqRepository : BaseLinqRepository<Location>, ILocationRepository
    {
        
        public LocationLinqRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<Location> ReadAllLocationList()
        {
            List<Location> locationList = new List<Location>();
            
            using (var ctx = new DataContext("MusterAgDb")) {

                ITable<LocationEntity> locationTable = ctx.GetTable<LocationEntity>();
                IQueryable<LocationEntity> query = locationTable;
                foreach (LocationEntity locationEntity in query) {
                    Location location = new Location(locationEntity);
                    locationList.Add(location);
                }
     
            }

            return locationList;
        }

        public override string TableName => "Location";
    }
}