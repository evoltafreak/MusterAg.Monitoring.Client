using System;
using DuplicateCheckerLib;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class VLogentries : IEntity
    {
        public int Id { get; set; }
        public string Pod { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public string Severity { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Pod)}: {Pod}, {nameof(Location)}: {Location}, {nameof(Hostname)}: {Hostname}, {nameof(Severity)}: {Severity}, {nameof(Timestamp)}: {Timestamp}, {nameof(Message)}: {Message}";
        }

        protected bool Equals(VLogentries other)
        {
            return Severity == other.Severity && Message == other.Message;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VLogentries) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Severity, Message);
        }
        
    }
}
