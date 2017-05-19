namespace BLS.Core.Data
{
    public class UserProfile : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Preference { get; set; }
        public User Users { get; set; }
    }
}
