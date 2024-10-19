using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.Context;


namespace Infrastructure.Data;

public class ProfessionalRepository : IProfessionalRepository
{
    private readonly ServiTurnosDbContext _context;

    public ProfessionalRepository(ServiTurnosDbContext context)
    {
        _context = context;
    }

    public List<Professional> GetProfessional()
    {
        return _context.Professional.ToList();
    }

    public Professional? GetProfessionalById(int id)
    {
        return _context.Professional.FirstOrDefault(x => x.Id.Equals(id));
    }

    public List<Professional> GetProfessionalByProfession(Profession profession)
    {
        return _context.Professional.Where(professional => professional.Profession == profession).ToList();
    }

    public void AddProfessional(Professional entity)
    {
        _context.Professional.Add(entity);
        _context.SaveChanges();
    }

    public void UpdateProfessional(Professional entity)
    {
        _context.Professional.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteProfessional(Professional professional)
    {
        _context.Professional.Remove(professional);
        _context.SaveChanges();
    }

}