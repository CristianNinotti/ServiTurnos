namespace Application.Services
{
    public interface ISuperAdminService
    {
        void DeleteUser(int UserId);
        void ManageUser(int UserId);
    }
}

