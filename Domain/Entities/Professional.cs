using Domain.Enum;

namespace Domain.Entities
{

    public class Professional: User
    {
        public int Fee { get; set; }        
        public Profession Profession  { get; set; }
        public List<Meeting> Meetings { get; set; } = new List<Meeting>();

        public Professional() {
            TypeCustomer = "Professional";
        }

        
    }
}
