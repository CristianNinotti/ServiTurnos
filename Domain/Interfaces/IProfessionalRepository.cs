using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    internal interface IProfessionalRepository
    {
        List<Professional> GetProfessionals();
        Professional? GetProfessionalsById(int id);
        List<Professional> GetProfessionalByProfession(Profession profession);
        void AddProfessional(Professional entity);
        void UpdateProfessional(Professional entity);
        void DeleteProfessional(Professional entity);
    }
}
