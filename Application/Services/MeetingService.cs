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

        public MeetingService(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
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

        public void CreateMeeting(MeetingRequest meeting)
        {
            var meetingEntity = MeetingProfile.ToMeetingEntity(meeting); 
            _meetingRepository.AddMeeting(meetingEntity);
        }

        public bool UpdateMeeting(int id, MeetingRequest meeting)
        {
            var meetingEntity = _meetingRepository.GetMeetingById(id);

            if (meetingEntity != null)
            {
                MeetingProfile.ToMeetingEntityUpdate(meetingEntity, meeting); 
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
