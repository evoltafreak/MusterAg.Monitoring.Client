using System;
using System.Collections.Generic;

namespace MusterAg.Monitoring.Client.Models
{
    public partial class Location
    {
        public Location()
        {
            Customer = new HashSet<Customer>();
            Device = new HashSet<Device>();
        }

        public int IdLocation { get; set; }
        public string Address { get; set; }
        public string AddressNr { get; set; }
        public int FidPlace { get; set; }
        public int? Parent { get; set; }

        public virtual Place FidPlaceNavigation { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        
        protected bool Equals(Location other)
        {
            return IdLocation == other.IdLocation && Address == other.Address && AddressNr == other.AddressNr && FidPlace == other.FidPlace && Parent == other.Parent;
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
            return HashCode.Combine(IdLocation, Address, AddressNr, FidPlace, Parent);
        }

        public override string ToString()
        {
            return $"{nameof(IdLocation)}: {IdLocation}, {nameof(Address)}: {Address}, {nameof(AddressNr)}: {AddressNr}, {nameof(FidPlace)}: {FidPlace}, {nameof(Parent)}: {Parent}";
        }
        
    }
}
