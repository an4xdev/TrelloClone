namespace Trello.Api.Models;

public class DayFree
{
    public int ID { get; set; }
    public DateOnly Date { get; set; }

    public bool IsFree { get; set; }
}
