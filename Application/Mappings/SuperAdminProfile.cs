using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using DomainEntity = Domain.Entities;

namespace Application.Mappings
{
    public static class SuperAdminProfile
    {
        public static DomainEntity.SuperAdmin ToSuperAdminEntity(SuperAdminRequest request)
        {
            return new DomainEntity.SuperAdmin()
            {
                UserName = request.UserName,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Dni = request.Dni,
                Email = request.Email,
                TypeCustomer = request.TypeCustomer

            };
        }

        public static void ToSuperAdminEntityUpdate(DomainEntity.SuperAdmin superAdmin, SuperAdminRequest request)
        {
            superAdmin.FirstName = request.FirstName;
            superAdmin.LastName = request.LastName;
            superAdmin.Dni = request.Dni;
        }

        public static SuperAdminResponse ToSuperAdminResponse(DomainEntity.SuperAdmin superAdmin)
        {
            return new SuperAdminResponse()
            {
                Id = superAdmin.Id,
                UserName = superAdmin.UserName,
                FirstName = superAdmin.FirstName,
                LastName = superAdmin.LastName,
                Dni = superAdmin.Dni,
                Email = superAdmin.Email,
                TypeCustomer = superAdmin.TypeCustomer
            };
        }

        public static List<SuperAdminResponse> ToSuperAdminResponse(List<DomainEntity.SuperAdmin> superAdmins)
        {
            return superAdmins.Select(s => new SuperAdminResponse
            {
                Id = s.Id,
                UserName = s.UserName,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Dni = s.Dni,
                Email = s.Email,
                TypeCustomer = s.TypeCustomer

            }).ToList();
        }
    }
}

