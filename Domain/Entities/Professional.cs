using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Professional: User
    {
        public int Fee { get; set; }    
        // public float Calification {  get; set; }
        // public List<Meet> Meetings { get; set; }
        public Profession Profession  { get; set; }
    }
}
