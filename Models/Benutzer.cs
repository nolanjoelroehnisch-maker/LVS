namespace LVS.Models
{
    public class Benutzer
    {
        public int Id { get; set; }
        public string Benutzername { get; set; } = "";
        public byte[] PasswortHash { get; set; } = []; //Rfc2898DeriveBytes-Klasse (PBKDF2)
        public byte[] PasswortSalt { get; set; } = []; // Später 18.10 Hat noch kein Anfangswert , wird beim Erstellen des Benutzers gesetzt
        public string Rolle { get; set; } = "";
        public string Email { get; set; } = "";
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public string Telefonnummer { get; set; } = "";
        public string Benutzerstatus { get; set; } = "";
        public DateTime? LetzterLogin { get; set; }  
        public DateTime Erstellungsdatum { get; set; } 
        public string Berechtigungen { get; set; } = ""; //später wahrscheinlich besser strukturiert als einfacher string

    }
}
