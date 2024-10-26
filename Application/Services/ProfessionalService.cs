using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Enum;
using Domain.Interfaces;


namespace Application.Services
{

    public class ProfessionalService : IProfessionalService
    {
        private readonly IProfessionalRepository _professionalRepository;

        public ProfessionalService(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        public List<ProfessionalResponse> GetAllProfessional()
        {
            try
            {
                var professionals = _professionalRepository.GetProfessional();

                return ProfessionalsProfile.ToProfessionalResponse(professionals);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hay un error en la clase");
                throw new Exception(e.Message);
            }
        }

        public ProfessionalResponse? GetProfessionalById(int id)
        {
            var professional = _professionalRepository.GetProfessionalById(id);

            if (professional != null)
            {
                return ProfessionalsProfile.ToProfessionalResponse(professional);
            }

            return null;
        }

        public List<ProfessionalResponse> GetProfessionalByProfession(Profession profession)
        {
            var professionals = _professionalRepository.GetProfessionalByProfession(profession);

            if (professionals == null || !professionals.Any())
            {
                throw new InvalidOperationException($"No se encontraron profesionales con la profesión: {profession}");
            }

            return ProfessionalsProfile.ToProfessionalResponse(professionals);
        }
        public void CreateProfessional(ProfessionalRequest professional)
        {
            var professionalEntity = ProfessionalsProfile.ToProfessionalEntity(professional);
            _professionalRepository.AddProfessional(professionalEntity);
        }


        public bool UpdateProfessional(int id, ProfessionalRequest professional)
        {
            var professionalEntity = _professionalRepository.GetProfessionalById(id);

            if (professionalEntity != null)
            {

                if (!string.IsNullOrEmpty(professional.UserName) && professional.UserName != "string")
                {
                    professionalEntity.UserName = professional.UserName;
                }

                if (!string.IsNullOrEmpty(professional.Password) && professional.Password != "string")
                {
                    professionalEntity.Password = professional.Password;
                }

                if (!string.IsNullOrEmpty(professional.FirstName) && professional.FirstName != "string")
                {
                    professionalEntity.FirstName = professional.FirstName;
                }

                if (!string.IsNullOrEmpty(professional.LastName) && professional.LastName != "string")
                {
                    professionalEntity.LastName = professional.LastName;
                }

                if (professional.Dni != 0)
                {
                    professionalEntity.Dni = professional.Dni;
                }

                if (!string.IsNullOrEmpty(professional.Email) && professional.Email != "string")
                {
                    professionalEntity.Email = professional.Email;
                }


                _professionalRepository.UpdateProfessional(professionalEntity);
                return true;
            }

            return false;
        }

        public bool DeleteProfessional(int id)
        {
            var professional = _professionalRepository.GetProfessionalById(id);

            if (professional != null)
            {
                _professionalRepository.DeleteProfessional(professional);

                return true;
            }

            return false;
        }

    }
}