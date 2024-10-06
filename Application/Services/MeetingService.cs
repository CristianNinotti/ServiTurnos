using Domain.Entities;
using Application.Interfaces;
// acá implementamos la interfaz de IMeetingService
namespace Application.Services
{
    public class MeetingService : IMeetingService // implementa la interfaz, es decir asegura que el contrato se cumpla
        //Inyeccion de dependencias. Inicializamos el constructor
        private readonly IMeetingRepository _meetingRepository;
    // toma la un parametro de tipo MeetingService y lo asigna al atributo privado _meetingRepository
    public MeetingService(IMeetingRepository meetingRepository)
    {
        _meetingRepository = meetingRepository;
    }
    // acá ponemos los metodos de clase Meeting
    public void CreateMeeting(Meeting meeting)
    {
        _meetingRepository.Add(meeting);
    }

    public Meeting GetMeetingById(int id)
    {
        return _meetingRepository.GetById(id);
    }

    public void DeleteMeeting(int id)
    {
        _meetingRepository.Delete(id);
    }

    public void UpdateMeeting(Meeting meeting)
    {
        _meetingRepository.Update(meeting);
    }

    public List<Meeting> GetAllMeetings()
    {
        return _meetingRepository.GetAll();
    }
}
}
