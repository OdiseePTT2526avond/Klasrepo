using System.Collections.ObjectModel;

namespace Mijnbib.Models;

/// <summary>
/// Represents a work (book, e-book, DVD, etc.) in the library
/// </summary>
public class Werk
{
    public int WerkNr { get; set; }
    public string Naam { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;

    /// <summary>
    /// De uitleningen van dit werk (in-memory only, bidirectional relationship)
    /// </summary>
    public ObservableCollection<Uitlening> Uitleningen { get; set; } = new();

    /// <summary>
    /// Is dit ingeleverd?
    /// Requirement Req31: Mijnbib can determine if a work is already loaned out or not
    /// </summary>
    public bool IsUitgeleend => Uitleningen.Any(u => u.InleverDatum == null);

    public override string ToString()
    {
        return $"{Naam} - {Auteur} (#{WerkNr})";
    }
}
