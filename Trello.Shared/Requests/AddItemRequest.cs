namespace Trello.Shared.Requests
{
    public class AddItemRequest
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectID { get; set; }

        public int ColumnID { get; set; }
    }
}
