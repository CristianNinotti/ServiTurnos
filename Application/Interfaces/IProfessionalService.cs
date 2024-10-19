using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IProfessionalService
    {
        List<ProfessionalResponse> GetAllProfessional();
        ProfessionalResponse? GetProfessionalById(int id);
        List<ProfessionalResponse> GetProfessionalByProfession(Profession profession);
        void CreateProfessional(ProfessionalRequest professional);
        bool UpdateProfessional(int id, ProfessionalRequest professional);
        bool DeleteProfessional(int id);
    }
}
