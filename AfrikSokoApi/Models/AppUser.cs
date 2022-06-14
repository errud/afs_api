namespace AfrikSokoApi.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
