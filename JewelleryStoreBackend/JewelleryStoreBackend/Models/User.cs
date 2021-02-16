namespace JewelleryStoreBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPrivileged { get; set; }
    }
}
