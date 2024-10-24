using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Interfaces;

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


        public static Meeting ToMeetingEntity(MeetingRequest meetingRequest, Customer customer, Professional professional)
        {
            return new Meeting
            {
                Date = meetingRequest.Date,
                Customer = customer ?? throw new Exception("Customer not found."),
                Professional = professional ?? throw new Exception("Professional not found.")
            };
        }


        public static void ToMeetingEntityUpdate(Meeting meetingEntity, MeetingRequest meetingRequest, ICustomerRepository customerRepository, IProfessionalRepository professionalRepository)
        {
            meetingEntity.Date = meetingRequest.Date;

            
            var customer = customerRepository.GetCustomerById(meetingRequest.CustomerId);
            if (customer != null)
            {
                meetingEntity.Customer = customer;
            }
            else
            {
                throw new Exception($"Customer with ID {meetingRequest.CustomerId} not found.");
            }

            
            var professional = professionalRepository.GetProfessionalById(meetingRequest.ProfessionalId);
            if (professional != null)
            {
                meetingEntity.Professional = professional;
            }
            else
            {
                throw new Exception($"Professional with ID {meetingRequest.ProfessionalId} not found.");
            }
        }
    }
}

