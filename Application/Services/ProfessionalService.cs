using Domain.Entities;
using Application.Interfaces;

namespace Application.Services
{//Inyeccion de dependencia
    public class ProfessionalService : IProfessionalService
    {
        private readonly IProfessionalRepository
        //Constructor
        public ProfessionalService(IProfessionalService, professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }
        //Logica de metodos.
        public void AcceptRequest(int ResquestId)
        {

        }

        public void RejectRequest(int RequestId)
        {

        }
        public void CalculateRate(int ProfessionalId)
        {

        }
    }

}
