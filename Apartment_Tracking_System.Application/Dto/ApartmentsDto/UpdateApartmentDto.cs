using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Dto.ApartmentsDto
{
    public class UpdateApartmentDto
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string ApartmentName { get; set; }
        public string Address { get; set; }
        public int FlatNumber { get; set; }
    }
}
