using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IMeetingRepository
    {
        
        List<Meeting> GetMeetings();        
        Meeting? GetMeetingById(int id);        
        List<Meeting> GetMeetingsByProfessional(int professionalId);        
        List<Meeting> GetMeetingsByCustomer(int customerId);        
        void AddMeeting(Meeting meeting);        
        void UpdateMeeting(Meeting meeting);        
        void DeleteMeeting(Meeting meeting);
    }
}