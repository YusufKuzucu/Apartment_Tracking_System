using Apartment_Tracking_System.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Tracking_System.Domain.Entities
{
    public class Apartment:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string ApartmentName { get; set; }
        public string Address { get; set; }
        public int FlatNumber { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Flat> Flats { get; set; }
    }

}
