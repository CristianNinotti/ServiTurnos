﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; } 
        public string UserName {  get; set; }   
        public string Password { get; set; }    

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Dni {  get; set; }   
        public string Email { get; set; }   

        public string TypeCustomer { get; set; }


    }
}
