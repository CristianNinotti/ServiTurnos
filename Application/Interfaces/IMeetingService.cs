using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IMeetingService
    {
        List<MeetingResponse> GetAllMeetings();
        MeetingResponse? GetMeetingById(int id);
        List<MeetingResponse> GetMeetingsByProfessional(int professionalId);
        List<MeetingResponse> GetMeetingsByCustomer(int customerId);
        void CreateMeeting(MeetingRequest meeting);
        bool UpdateMeeting(int id, MeetingRequest meeting);
        bool DeleteMeeting(int id);
    }
}
