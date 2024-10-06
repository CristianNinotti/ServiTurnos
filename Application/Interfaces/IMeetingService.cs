namespace Application.Services
{//Esta es la interfaz de servicio del turno. este es el contrato que que las clases que implmenten esto deben cumplirlo
    public interface IMeetingService
    {
        void CreateMeeting(Meeting meeting);//Crea un turno por id
        Meeting GetMeetingById(int id); //devuelve un objeto de tipo Meeting
        void DeleteMeeting(int id); //Elimina un turno por Id
        void UpdateMeeting(Meeting meeting);//Modifica un turno por id
        List<Meeting> GetAllMeetings();//Obtiene todo el listado de los turnos
    }
}

