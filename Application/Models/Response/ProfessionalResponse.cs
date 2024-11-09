﻿using Domain.Entities;
using Domain.Enum;

namespace Application.Models.Response
{
    public class ProfessionalResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Dni { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Fee { get; set; }

        public Profession Profession { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;



    }
}