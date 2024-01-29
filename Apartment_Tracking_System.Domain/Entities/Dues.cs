using Apartment_Tracking_System.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Tracking_System.Domain.Entities
{
    public class Dues: IEntity
    {
        [Key]
        public int Id { get; set; }
        public int FlatId { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public Flat Flat { get; set; }
    }

}
