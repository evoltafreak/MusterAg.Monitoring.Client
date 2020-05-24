using System;

namespace MusterAg.Monitoring.Client.Model
{
    public class Location
    {
        public long IdLocation { get; set; }
        public string Address { get; set; }
        public string AddressNr { get; set; }
        public long FidPlace { get; set; }

        protected bool Equals(Location other)
        {
            return IdLocation == other.IdLocation && Address == other.Address && AddressNr == other.AddressNr && FidPlace == other.FidPlace;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdLocation, Address, AddressNr, FidPlace);
        }

        public override string ToString()
        {
            return $"{nameof(IdLocation)}: {IdLocation}, {nameof(Address)}: {Address}, {nameof(AddressNr)}: {AddressNr}, {nameof(FidPlace)}: {FidPlace}";
        }
        
    }
}