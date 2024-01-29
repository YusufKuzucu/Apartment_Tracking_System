using Apartment_Tracking_System.Application.Dto.ApartmentsDto;
using Apartment_Tracking_System.Application.Dto.DuesDto;
using Apartment_Tracking_System.Application.Dto.FlatDto;
using Apartment_Tracking_System.Application.Dto.ManagersDto;
using Apartment_Tracking_System.Application.Dto.TenantsDto;
using Apartment_Tracking_System.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Manager, ManagerListDto>().ReverseMap();
            CreateMap<Manager, CreateManagerDto>().ReverseMap();
            CreateMap<Manager, UpdateManagerDto>().ReverseMap();
            CreateMap<Manager, RemoveManagerDto>().ReverseMap();

            CreateMap<Apartment, ApartmentListDto>().ReverseMap();
            CreateMap<Apartment, CreateApartmentDto>().ReverseMap();
            CreateMap<Apartment, UpdateApartmentDto>().ReverseMap();
            CreateMap<Apartment, RemoveApartmentDto>().ReverseMap();

            CreateMap<Tenant, TenantListDto>().ReverseMap();
            CreateMap<Tenant, CreateTenantDto>().ReverseMap();
            CreateMap<Tenant, UpdateTenantDto>().ReverseMap();
            CreateMap<Tenant, RemoveTenantDto>().ReverseMap();

            CreateMap<Flat, FlatListDto>().ReverseMap();
            CreateMap<Flat, CreateFlatDto>().ReverseMap();
            CreateMap<Flat, UpdateFlatDto>().ReverseMap();
            CreateMap<Flat, RemoveFlatDto>().ReverseMap();

            CreateMap<Dues, DuesListDto>().ReverseMap();
            CreateMap<Dues, CreateDuesDto>().ReverseMap();
            CreateMap<Dues, UpdateDuesDto>().ReverseMap();
            CreateMap<Dues, RemoveDuesDto>().ReverseMap();
        }
    }
}
