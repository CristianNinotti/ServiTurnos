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
                ProfessionalsProfile.ToProfessionalEntityUpdate(professionalEntity, professional);

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

