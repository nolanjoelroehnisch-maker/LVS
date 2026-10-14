namespace LVS.Models
{
    public class Benutzer
    {
        public int Id { get; set; }
        public string Benutzername { get; set; } = "";
        public string Passwort { get; set; } = ""; // später nur im Hash-Format speichern
        public string Rolle { get; set; } = "";
        public string Email { get; set; } = "";
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public string Telefonnummer { get; set; } = "";
        public string Benutzerstatus { get; set; } = "";
        public string LetzterLogin { get; set; } = ""; // später als DateTime speichern
        public string Erstellungsdatum { get; set; } = "";// später als DateTime speichern
        public string Berechtigungen { get; set; } = ""; //später wahrscheinlich besser strukturiert als einfacher string

    }
}
