namespace Trello.Client.Models
{
    public class ColumnModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ColumnModel other = (ColumnModel)obj;
            return ID == other.ID && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name);
        }
    }
}
