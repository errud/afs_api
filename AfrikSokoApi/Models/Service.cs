namespace AfrikSokoApi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Period { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}
