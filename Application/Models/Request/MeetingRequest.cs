namespace Application.Models.Request
{
    public class MeetingRequest
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int ProfessionalId { get; set; }
    }
}