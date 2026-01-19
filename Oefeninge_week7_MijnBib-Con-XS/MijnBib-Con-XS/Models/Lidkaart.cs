using System.Collections.ObjectModel;

namespace Mijnbib.Models;

/// <summary>
/// 1 lid = lidkaart
/// </summary>
public class Lidkaart
{
    public int LidNummer { get; set; }
    public string LidNaam { get; set; } = string.Empty;

    /// <summary>
    /// Alle uitleningen (in-memory only, bidirectional relationship)
    /// Requirement Req20: Mijnbib kent alle ontleningen van elk lid
    /// </summary>
    public ObservableCollection<Uitlening> Uitleningen { get; set; } = new();

    /// <summary>
    /// Het aantal open uitleningen (nog niet ingeleverd)
    /// </summary>
    public int AantalOpenUitleningen => Uitleningen.Count(u => u.InleverDatum == null);


    public override string ToString()
    {
        return $"{LidNaam} (#{LidNummer})";
    }
}
