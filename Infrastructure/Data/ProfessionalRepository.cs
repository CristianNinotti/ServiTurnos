using Domain.Entities;
using Domain.Enum;

namespace Infrastructure.Data;

public class ProfessionalRepository : IProfessionalRepository
{
    private readonly DbContext _context;

    public ProfessionalRepository(DbContext context)
    {
        _context = context;
    }

    public List<Professional> GetProfessionals()
    {
        return _context.Professionals.ToList();
    }

    public Professional? GetProfessionalById(int id)
    {
        return _context.Professionals.FirstOrDefault(x => x.Id.Equals(id));
    }

    public List<Professional> GetProfessionalsByProfession(Profession profession)
    {
        return _context.Professionals.Where(professional => professional.Profession == profession).ToList();
    }

    public void AddProfessional(Professional entity)
    {
        _context.Professional.Add(entity);
        _context.SaveChanges();
    }

    public void UpdateProfessional(Professional entity)
    {
        _context.Professionals.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteProfessional(Professional professional)
    {
        _context.Professionals.Remove(professional);
        _context.SaveChanges();
    }
}