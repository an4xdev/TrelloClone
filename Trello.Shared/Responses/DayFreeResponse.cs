namespace Trello.Shared.Responses;

public class DayFreeResponse
{
    public DayFreeType DayFreeType { get; set; }

    public bool IsFree { get; set; }
}

public enum DayFreeType
{
    DaySet,
    DayDontSet
}
