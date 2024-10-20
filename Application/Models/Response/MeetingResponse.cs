namespace Application.Models.Response
{
    public class MeetingResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; } 
        public int ProfessionalId { get; set; } 
    }
}
