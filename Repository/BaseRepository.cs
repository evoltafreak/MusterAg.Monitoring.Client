using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    public abstract class BaseRepository<M> : IBaseRepository<M>
    {
        public string ConnectionString { get; set; }
        public abstract string TableName { get; }
        
        public long Count() {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"SELECT COUNT(*) FROM {TableName}";
                    return (long) cmd.ExecuteScalar();
                }
            }
        }
        public M GetSingle<P>(P pkValue)
        {
            throw new System.NotImplementedException();
        }

        public void Add(M entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(M entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(M entity)
        {
            throw new System.NotImplementedException();
        }

        public List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new System.NotImplementedException();
        }

        public List<M> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new System.NotImplementedException();
        }
        
    }
}