using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;

namespace MusterAg.Monitoring.Client.Repository
{
    public abstract class BaseLinqRepository<M> : IBaseRepository<M> where M : class
    {
        public string ConnectionString { get; set; }
        public abstract string TableName { get; }
        
        public virtual long Count() {
            using (var ctx = new DataContext("MusterAgDb")) {
                ITable<M> table = ctx.GetTable<M>();
                int count = table.Count();
                return count;
            }
        }
        public virtual M GetSingle<P>(P pkValue)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(M entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(M entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(M entity)
        {
            throw new NotImplementedException();
        }

        public virtual List<M> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public virtual List<M> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }
        
    }
}