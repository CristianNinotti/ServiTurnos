using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Mappings
{
    public static class MeetingProfile
    {
        
        public static MeetingResponse ToMeetingResponse(Meeting meeting)
        {
            return new MeetingResponse
            {
                Id = meeting.Id,
                Date = meeting.Date,
                CustomerId = meeting.Customer?.Id ?? 0, 
                ProfessionalId = meeting.Professional?.Id ?? 0 
            };
        }

        
        public static List<MeetingResponse> ToMeetingResponse(List<Meeting> meetings)
        {
            var responses = new List<MeetingResponse>();
            foreach (var meeting in meetings)
            {
                responses.Add(ToMeetingResponse(meeting));
            }
            return responses;
        }

        
        public static Meeting ToMeetingEntity(MeetingRequest meetingRequest)
        {
            return new Meeting
            {
                Date = meetingRequest.Date,
                Customer = new Customer { Id = meetingRequest.CustomerId }, 
                Professional = new Professional { Id = meetingRequest.ProfessionalId } // acá creamos un nuevo objeto Professional
            };
        }

        
        public static void ToMeetingEntityUpdate(Meeting meetingEntity, MeetingRequest meetingRequest)
        {
            meetingEntity.Date = meetingRequest.Date;

            
            if (meetingEntity.Customer != null)
            {
                meetingEntity.Customer.Id = meetingRequest.CustomerId;
            }
            else
            {
                meetingEntity.Customer = new Customer { Id = meetingRequest.CustomerId }; 
            }

            
            if (meetingEntity.Professional != null)
            {
                meetingEntity.Professional.Id = meetingRequest.ProfessionalId;
            }
            else
            {
                meetingEntity.Professional = new Professional { Id = meetingRequest.ProfessionalId }; 
            }
        }
    }
}

