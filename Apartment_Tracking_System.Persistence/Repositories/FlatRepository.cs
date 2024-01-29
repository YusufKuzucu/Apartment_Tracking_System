using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Apartment_Tracking_System.Domain.Entities;
using Apartment_Tracking_System.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Persistence.Repositories
{
    public class FlatRepository : BaseRepository<Flat>, IFlatService
    {
        private readonly ApplicationDbContext _context;
        public FlatRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public async Task<bool> FlatExistByFlatNoAsync(int flatNo)
        {
            return await _context.Set<Flat>().AnyAsync(f => f.FlatNo == flatNo);
        }

        public async Task<int> GetFlatCountByApartmentIdAsync(int apartmentId)
        {
            return await _context.Set<Flat>().CountAsync(f => f.ApartmentId == apartmentId);
        }
    }
}
