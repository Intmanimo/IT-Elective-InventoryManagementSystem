namespace BakeshopInventorySystem.Models
{
    public class Supplier
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public Supplier(int id, string name, string contact)
        {
            Id = id;
            Name = name;
            ContactNumber = contact;
        }
    }
}