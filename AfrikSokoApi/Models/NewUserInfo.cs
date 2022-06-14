namespace AfrikSokoApi.Models
{
    public class NewUserInfo
    { 
        public string Email { get; set; } = string.Empty;
        public string Passwd { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;

        public IEnumerable<int> FavoriteId { get; set; }
    }
}
