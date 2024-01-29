using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Dto.DuesDto
{
    public class CreateDuesDto
    {
        public int FlatId { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
