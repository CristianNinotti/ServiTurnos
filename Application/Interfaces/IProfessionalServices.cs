using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;

namespace Application.Interfaces
{
    internal interface IProfessionalServices
    {
        List<ProfessionalResponse> GetAllProfessional();
        ProfessionalResponse? GetProfessionalById(int id);
        List<ProfessionalResponse> GetProfessionalsByProfession(Profession profession);
        void CreateProfessional(ProfessionalRequest professional);
        bool UpdateProfessional(int id, ProfessionalRequest professional);
        bool DeleteProfessional(int id);
    }
}
