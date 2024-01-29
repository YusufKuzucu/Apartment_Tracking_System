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
    public class ManagerRepository : BaseRepository<Manager>, IManagerService
    {
        public ManagerRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}
