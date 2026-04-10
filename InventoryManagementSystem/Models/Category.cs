namespace BakeshopInventorySystem.Models
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}