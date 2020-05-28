using LinqToDB.Mapping;

namespace MusterAg.Monitoring.Client.Model
{
    public class Pod
    {
        public long IdPod { get; set; }
        public string Description { get; set; }
        public decimal BillLimit { get; set; }
        public decimal Credit { get; set; }
        
        public Pod() {}

        public Pod(PodEntity podEntity)
        {
            IdPod = podEntity.IdPod;
            Description = podEntity.Description;
            BillLimit = podEntity.BillLimit;
            Credit = podEntity.Credit;
        }
        
    }

    [Table("pod")]
    public partial class PodEntity
    {
        [Column("idPod"), PrimaryKey, NotNull]
        public long IdPod { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("billLimit")]
        public decimal BillLimit { get; set; }
        [Column("credit")]
        public decimal Credit { get; set; }
    }
    
}