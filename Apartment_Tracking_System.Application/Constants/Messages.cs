using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment_Tracking_System.Application.Constants
{
    public static class Messages
    {
        public static string ManagerAdded = "Administrator Added.";
        public static string ApartmentAdded = "Apartment Added..";
        public static string FlatAdded = "Flat Added.";
        public static string DuesAdded = "Dues Added.";
        public static string TenantAdded = "Tenant Added.";

        public static string ManagerUpdated = "Administrator Updated.";
        public static string ApartmentUpdated = "Apartment Updated.";
        public static string FlatUpdated = "Flat Updated.";
        public static string DuesUpdated = "Dues Updated.";
        public static string TenantUpdated = "Tenant Updated.";

        public static string ManagerRemove = "Administrator Deleted.";
        public static string ApartmentRemove = "Apartment Deleted.";
        public static string FlatRemove = "Flat Deleted.";
        public static string DuesRemove = "Dues Deleted.";
        public static string TenantRemove = "Tenant Deleted.";

        public static string ManagerRemoveFailed = "No Administrator Found.";
        public static string ApartmentRemoveFailed = "No Apartment Found.";
        public static string FlatRemoveFailed = "No Flat Found.";
        public static string DuesRemoveFailed = "No Dues Found.";
        public static string TenantRemoveFailed = "No Tenant Found.";

        public static string ManagerGetAllFailed = "Managers Not Be Found.";
        public static string ApartmentGetAllFailed = "Apartments Not Be Found.";
        public static string FlatGetAllFailed = "Flats Not Be Found.";
        public static string DuesGetAllFailed = "Dues Not Be Found.";
        public static string TenantGetAllFailed = "Tenants Not Be Found.";


        public static string ManagerGetFailed = "Manager With ID not Found.";
        public static string ApartmentGetFailed = "Apartment With ID not Found.";
        public static string FlatGetFailed = " Flat With ID not Found.";
        public static string DuesGetFailed = "Dues With ID not Found.";
        public static string TenantGetFailed = "Tenant With ID not Found.";

        public static string FlatAddedApartmentFailed = "Apartment Capacity Full.";
        public static string FlatAddedFlatFailed = "This flat number is already in use. Please select another flat number.";
    }
}
