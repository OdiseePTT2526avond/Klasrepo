using System.Collections.Generic;

namespace OdiseeAdmin2.Models;

public class Docent
{
    // Statische lijst om alle docenten bij te houden
    public static List<Docent> Docenten { get; } = new();

    private string voornaam;
    private string achternaam;

    public Docent(string voornaam, string achternaam)
    {
        this.voornaam = voornaam;
        this.achternaam = achternaam;

        // Voeg zichzelf toe aan de statische lijst
        Docenten.Add(this);
    }

    public override string ToString() => $"{voornaam} {achternaam}";
}
