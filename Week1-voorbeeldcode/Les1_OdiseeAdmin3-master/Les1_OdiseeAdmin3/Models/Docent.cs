namespace OdiseeAdmin3.Models;

public class Docent
{
    public string Id { get; }
    public string Voornaam { get; }
    public string Achternaam { get; }

    public Docent(string id, string voornaam, string achternaam)
    {
        Id = id;
        Voornaam = voornaam;
        Achternaam = achternaam;
    }

    public override string ToString() => $"{Id} {Voornaam} {Achternaam}";
}
