﻿using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Apartment_Tracking_System.Domain.Entities;
using Apartment_Tracking_System.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Persistence.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentService
    {
        public ApartmentRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}
