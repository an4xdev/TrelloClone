namespace Trello.Shared
{
    public class TemplateWithCollumns
    {
        public Template Template { get; set; }

        public IEnumerable<Column> Columns { get; set; }
    }
}
