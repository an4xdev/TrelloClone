namespace Trello.Shared.Responses;

public class SummaryByTagsResponse
{
    public int Count { get; set; }

    public string Tag { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;
}
