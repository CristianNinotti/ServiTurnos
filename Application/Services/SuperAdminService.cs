using Application.Interfaces;

namespace Application.Services
{
    public class SuperAdminService : ISuperAdminService
        private readonly ISuperAdminRepository _superAdminRepository;
    public SuperAdminService(ISuperAdminRepository superAdminRepository)
    {
        _superAdminRepository = ISuperAdminRepository
        }

    public void DeleteUser(int UserId)
    {

    }

    public void ManageUser(int UserId)
    {

    }
}

