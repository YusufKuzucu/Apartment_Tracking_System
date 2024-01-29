using Apartment_Tracking_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Interfaces.Repositories
{
    public interface IFlatService : IBaseRepository<Flat>
    {
        Task<int> GetFlatCountByApartmentIdAsync(int apartmentId);
        Task<bool> FlatExistByFlatNoAsync(int flatNo);

    }
}
