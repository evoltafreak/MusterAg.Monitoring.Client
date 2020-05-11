namespace MusterAg.Monitoring.Client.Model
{
    public class Pod
    {
        public long IdPod { get; set; }
        public string Description { get; set; }
        public decimal BillLimit { get; set; }
        public decimal Credit { get; set; }
    }
}