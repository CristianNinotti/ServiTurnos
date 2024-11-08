using Domain.Entities;

namespace Application.Models.Request
{
    public class ProfessionalRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string   .Empty;
        public int Dni { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Fee { get; set; }
        public int Profession { get; set; }



    }

}