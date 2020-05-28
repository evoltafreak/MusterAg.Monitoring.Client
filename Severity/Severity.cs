using LinqToDB.Mapping;

namespace MusterAg.Monitoring.Client.Model
{
    public enum Severity
    {
        NOT_SET, FATAL, ERROR, WARN, INFO, DEBUG, TRACE
    }
    
    [Table("severity")]
    public partial class SeverityEntity
    {
        [Column("idSeverity"), PrimaryKey, NotNull]
        public long IdPod { get; set; }
        [Column("severity")]
        public string Severity { get; set; }
    }
    
}
