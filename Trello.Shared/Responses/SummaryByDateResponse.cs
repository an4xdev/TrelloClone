namespace Trello.Shared.Responses;

public class SummaryByDateResponse
{
    public DateOnly? Date { get; set; }

    public int Count { get; set; }
}
