using Apartment_Tracking_System.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Tracking_System.Domain.Entities
{
    public class Flat: IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int TenantId { get; set; } 
        public int FlatNo { get; set; }
        public int RoomNumber { get; set; }
        public bool IsVacant { get; set; }
        public Tenant Tenant { get; set; } 
        public ICollection<Dues> Dues { get; set; }
        public Apartment Apartment { get; set; }
    }

}
