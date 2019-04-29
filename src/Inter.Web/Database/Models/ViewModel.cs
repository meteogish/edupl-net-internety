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
    }
}
