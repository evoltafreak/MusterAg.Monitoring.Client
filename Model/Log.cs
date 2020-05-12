using System;
using DuplicateCheckerLib;

namespace MusterAg.Monitoring.Client.Model
{
    public class Log : IEntity
    {
        public long IdPod { get; set; }
        public string Pod { get; set; }
        public string Location { get; set; }
        public string Hostname { get; set; }
        public Severity Severity { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(IdPod)}: {IdPod}, {nameof(Pod)}: {Pod}, {nameof(Location)}: {Location}, {nameof(Hostname)}: {Hostname}, {nameof(Severity)}: {Severity}, {nameof(Timestamp)}: {Timestamp}, {nameof(Message)}: {Message}";
        }

        protected bool Equals(Log other)
        {
            return Severity == other.Severity && Message == other.Message;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Log) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Severity, Message);
        }
    }
}