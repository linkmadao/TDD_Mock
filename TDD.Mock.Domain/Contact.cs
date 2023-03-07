namespace TDD.Mock.Domain
{
    public class Contact
    {
        public Contact()
        {
            Telephone = new List<string>();
        }

        public Guid Id { get; set; }
        
        public string? Name { get; set; }

        public List<string> Telephone { get; set; }
    }
}