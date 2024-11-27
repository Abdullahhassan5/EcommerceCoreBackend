namespace ECommerceWebAPI.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password{ get; set; } // Use hashed passwords for security
    }
}
