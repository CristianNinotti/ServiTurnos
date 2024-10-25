using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;
using DomainEntity = Domain.Entities;

namespace Application.Mappings
{
    public static class ProfessionalsProfile
    {

        public static DomainEntity.Professional ToProfessionalEntity(ProfessionalRequest request)
        {
            return new DomainEntity.Professional()
            {
                UserName = request.UserName,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Dni = request.Dni,
                Email = request.Email,
                Fee = request.Fee,
                Profession = (Profession)request.Profession,

            };


        }

        public static void ToProfessionalEntityUpdate(DomainEntity.Professional professional, ProfessionalRequest request)
        {
            professional.FirstName = request.FirstName;
            professional.LastName = request.LastName;
            professional.Dni = request.Dni;
            professional.Fee = request.Fee;
            professional.Profession = (Profession)request.Profession;
        }

        public static ProfessionalResponse ToProfessionalResponse(DomainEntity.Professional professional)
        {
            return new ProfessionalResponse()
            {
                Id = professional.Id,
                FirstName = professional.FirstName,
                LastName = professional.LastName,
                Fee = professional.Fee,
                Profession = professional.Profession,
                Dni = professional.Dni,
                Email = professional.Email

            };
        }

        public static List<ProfessionalResponse> ToProfessionalResponse(List<DomainEntity.Professional> professional)
        {
            return professional.Select(p => new ProfessionalResponse
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Dni = p.Dni,
                Fee = p.Fee,
                Profession = p.Profession,
                Email = p.Email
            }).ToList();
        }
    }

}