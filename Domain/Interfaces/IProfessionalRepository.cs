using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IProfessionalRepository
    {
        List<Professional> GetProfessional();
        Professional? GetProfessionalById(int id);
        List<Professional> GetProfessionalByProfession(Profession profession);
        void AddProfessional(Professional entity);
        void UpdateProfessional(Professional entity);
        void DeleteProfessional(Professional entity);
    }
}
