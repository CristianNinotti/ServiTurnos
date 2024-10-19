using Application.Interfaces;
using Domain.Enum;

namespace Application.Services
{

    public class ProfessionalService : IProfessionalServices
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
                var professionals = _professionalRepository.GetProfessionals();

                return ProfessionalsProfile.ToProfessionalResponse(professionals);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en la clase {nameof(ProfessionalService)} - STACKTRACE: {e.StackTrace} - MESSAGE {e.Message}");
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

        public List<ProfessionalResponse> GetProfessionalsByProfession(Profession profession)
        {
            var professionals = _professionalRepository.GetMedicosByProfession(profession);

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

