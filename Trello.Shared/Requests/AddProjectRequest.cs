namespace Trello.Shared.Requests
{
    public class AddProjectRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int TemplateID { get; set; }
    }
}
