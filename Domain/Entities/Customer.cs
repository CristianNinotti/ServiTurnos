namespace Domain.Entities
{

    public class Customer : User
    {
        public List<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}

