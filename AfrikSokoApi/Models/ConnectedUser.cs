namespace AfrikSokoApi.Models
{
    public class ConnectedUser
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string NickName { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }
    }
}
