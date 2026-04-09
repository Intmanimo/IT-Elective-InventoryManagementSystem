namespace BakeshopInventorySystem.Models
{
    public class User
    {
        public int UserId { get; private set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public User(int id, string username, string role)
        {
            UserId = id;
            Username = username;
            Role = role;
        }
    }
}