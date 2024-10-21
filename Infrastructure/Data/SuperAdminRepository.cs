using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Data;

public class SuperAdminRepository : ISuperAdminRepository
{
    private readonly ServiTurnosDbContext _context;

    public SuperAdminRepository(ServiTurnosDbContext context)
    {
        _context = context;
    }

    public List<SuperAdmin> GetAllSuperAdmins()
    {
        return _context.SuperAdmins.ToList();
    }

    public SuperAdmin? GetSuperAdminById(int id)
    {
        return _context.SuperAdmins.FirstOrDefault(x => x.Id.Equals(id));
    }

    public void AddSuperAdmin(SuperAdmin entity)
    {
        _context.SuperAdmins.Add(entity);
        _context.SaveChanges();
    }

    public void UpdateSuperAdmin(SuperAdmin entity)
    {
        _context.SuperAdmins.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteSuperAdmin(SuperAdmin entity)
    {
        _context.SuperAdmins.Remove(entity);
        _context.SaveChanges();
    }
}
