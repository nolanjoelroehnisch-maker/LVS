namespace LVS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public byte[] PasswordHash { get; set; } = []; //Rfc2898DeriveBytes-Klasse (PBKDF2)
        public byte[] PasswordSalt { get; set; } = []; // Später 18.10 Hat noch kein Anfangswert , wird beim Erstellen des Users gesetzt
        public string Role { get; set; } = "";
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string UserStatus { get; set; } = "";
        public DateTime? LastLogin { get; set; }  
        public DateTime CreatedAt { get; set; } 
        public string Permissions { get; set; } = ""; //später wahrscheinlich besser strukturiert als einfacher string

    }
}
