using System;
using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace MusterAg.Monitoring.Client.Repository
{
    // Implementation not finished yet
    public abstract class GenericBaseRepository<M> : IBaseRepository<M>
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
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"SELECT * FROM {TableName} WHERE id{TableName} = @pkValue";
                    cmd.Parameters.AddWithValue("pkValue", pkValue);
                    return (M) cmd.ExecuteScalar();
                }
            }
        }

        public void Add(M entity)
        {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"INSERT INTO () VALUES(@)";
                    cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(M entity)
        {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"DELETE FROM {TableName} WHERE id{TableName} = @pkValue";
                    cmd.Parameters.AddWithValue("pkValue", null);
                    cmd.ExecuteScalar();
                }
            }
        }

        public void Update(M entity)
        {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"SELECT COUNT(*) FROM {TableName}";
                    cmd.ExecuteScalar();
                }
            }
        }

        public List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"SELECT COUNT(*) FROM {TableName}";
                    return (List<M>) cmd.ExecuteScalar();
                }
            }
        }

        public List<M> GetAll()
        {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"SELECT * FROM {TableName}";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt64(0));
                    }
                }
            }
            return new List<M>();
        }

        public long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            using (var conn = new MySqlConnection(ConnectionString)) {
                using (var cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.CommandText = $"SELECT COUNT(*) FROM {TableName}";
                    return (long) cmd.ExecuteScalar();
                }
            }
        }

        public string CreateInsertStatement()
        {
            string sqlQuery = $"INSERT INTO {TableName} (";
            List<PropertyInfo> propertyNameList = GetPropertyInfoList<M>();
            foreach (PropertyInfo propertyInfo in propertyNameList)
            {
                sqlQuery += propertyInfo.Name + ",";
            }

            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
            sqlQuery += ") VALUES (";
            foreach (PropertyInfo propertyInfo in propertyNameList)
            {
                sqlQuery += "@" + propertyInfo.Name + ",";
            }
            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
            sqlQuery += ")";
            return sqlQuery;
        }
        
        public string CreateUpdateStatement()
        {
            string sqlQuery = $"UPDATE {TableName} SET ";
            List<PropertyInfo> propertyNameList = GetPropertyInfoList<M>();
            foreach (PropertyInfo propertyInfo in propertyNameList)
            {
                sqlQuery += propertyInfo.Name + "=@" +
                            propertyInfo
                                .Name + ",";  //(propertyInfo.PropertyType == typeof(string) ? $"'{propertyInfo.Name}'" : propertyInfo.Name) + ",";
            }
            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 1);
            return sqlQuery;
        }

        public List<PropertyInfo> GetPropertyInfoList<T>()
        {
            return new List<PropertyInfo>(typeof(T).GetProperties());
        }
        
    }

}