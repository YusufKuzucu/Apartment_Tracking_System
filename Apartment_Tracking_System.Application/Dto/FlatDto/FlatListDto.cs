using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Dto.FlatDto
{
    public class FlatListDto
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int TenantId { get; set; } ///
        public int FlatNo { get; set; }
        public int RoomNumber { get; set; }
        public bool IsVacant { get; set; }
    }
}
