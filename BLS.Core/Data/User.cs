namespace BLS.Core.Data
{
    public class User : BaseEntity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserProfile Profile { get; set; }
    }
}
