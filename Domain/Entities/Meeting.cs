namespace Domain.Entities;

public class Meeting
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
 
    public Customer Customer { get; set; } = new();

    public Professional Professional { get; set; } = new();
}