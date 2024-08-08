namespace Trello.Shared.Responses;

public class SummaryGeneralResponse
{
    public int TotalTasks { get; set; }

    public int TotalProjects { get; set; }

    public LastDoneTask? LastDoneTask { get; set; }

}

public record LastDoneTask(string TaskName, DateOnly? Date, string ProjectName, int ProjectID);
