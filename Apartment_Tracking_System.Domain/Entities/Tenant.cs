using Apartment_Tracking_System.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Tracking_System.Domain.Entities
{
    public class Tenant: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public Flat Flat { get; set; } 
    }

}
