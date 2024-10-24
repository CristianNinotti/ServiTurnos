using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Application.Mappings;
using Domain.Interfaces;

namespace Application.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly ICustomerRepository _customerRepository;  // Esta es para poder manejar el pasaje de datos de Customer
        private readonly IProfessionalRepository _professionalRepository;  // Esta para poder manejar el pasaje de datos de Professional

        public MeetingService(IMeetingRepository meetingRepository,
                              ICustomerRepository customerRepository,
                              IProfessionalRepository professionalRepository)
        {
            _meetingRepository = meetingRepository;
            _customerRepository = customerRepository;
            _professionalRepository = professionalRepository;
        }

        public List<MeetingResponse> GetAllMeetings()
        {
            try
            {
                var meetings = _meetingRepository.GetMeetings();
                return MeetingProfile.ToMeetingResponse(meetings);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener todas las reuniones: {e.Message}");
                throw new Exception(e.Message);
            }
        }

        public MeetingResponse? GetMeetingById(int id)
        {
            var meeting = _meetingRepository.GetMeetingById(id);
            if (meeting != null)
            {
                return MeetingProfile.ToMeetingResponse(meeting);
            }
            return null;
        }

        public List<MeetingResponse> GetMeetingsByProfessional(int professionalId)
        {
            var meetings = _meetingRepository.GetMeetingsByProfessional(professionalId);
            return MeetingProfile.ToMeetingResponse(meetings);
        }

        public List<MeetingResponse> GetMeetingsByCustomer(int customerId)
        {
            var meetings = _meetingRepository.GetMeetingsByCustomer(customerId);
            return MeetingProfile.ToMeetingResponse(meetings);
        }

        public void CreateMeeting(MeetingRequest meetingRequest)
        {
            // Aca le pasamos las 3 cosas
            var meetingEntity = MeetingProfile.ToMeetingEntity(meetingRequest, _customerRepository, _professionalRepository);
            _meetingRepository.AddMeeting(meetingEntity);
        }

        public bool UpdateMeeting(int id, MeetingRequest meeting)
        {
            var meetingEntity = _meetingRepository.GetMeetingById(id);

            if (meetingEntity != null)
            {
                // Asegúrate de que tienes acceso a los repositorios de Customer y Professional en tu servicio
                var customerRepository = _customerRepository; // Asegúrate de tener este repositorio inyectado
                var professionalRepository = _professionalRepository; // Asegúrate de tener este repositorio inyectado

                // Actualiza la entidad Meeting usando los repositorios
                MeetingProfile.ToMeetingEntityUpdate(meetingEntity, meeting, customerRepository, professionalRepository);

                // Llama al repositorio para actualizar la entidad
                _meetingRepository.UpdateMeeting(meetingEntity);
                return true;
            }

            return false;
        }

        public bool DeleteMeeting(int id)
        {
            var meeting = _meetingRepository.GetMeetingById(id);
            if (meeting != null)
            {
                _meetingRepository.DeleteMeeting(meeting);
                return true;
            }

            return false;
        }
    }
}
