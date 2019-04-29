namespace Inter.Web.Database.Models
{
    public class ViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ViewModel(long id, string name)
        {
            Id = id;
            Name = name;
        }

        override public bool Equals(object obj) => obj is ViewModel other && other.Id == this.Id && other.Name == this.Name;

        override public int GetHashCode() => Id.GetHashCode() ^ (Name?.GetHashCode() ?? -1.GetHashCode());
    }
}
