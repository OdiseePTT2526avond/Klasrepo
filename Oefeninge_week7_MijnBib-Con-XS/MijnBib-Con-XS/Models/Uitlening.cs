namespace Mijnbib.Models;

/// <summary>
/// een uitlening van een werk aan een lid
/// </summary>
public class Uitlening
{
    public int UitleningId { get; set; }
    public int LidNummer { get; set; }
    public int WerkNr { get; set; }
    public DateTime UitleenDatum { get; set; }
    public DateTime? InleverDatum { get; set; }

    /// <summary>
    /// Navigation property to the member (in-memory only)
    /// </summary>
    public Lidkaart? Lidkaart { get; set; }

    /// <summary>
    /// Navigation property to the work (in-memory only)
    /// </summary>
    public Werk? Werk { get; set; }

    /// <summary>
    /// Gets the expected return date (21 days from loan date)
    /// </summary>
    public DateTime VerwachteInleverDatum => UitleenDatum.AddDays(21);

    public override string ToString()
    {
        return $"Uitlening #{UitleningId} - Werk #{WerkNr} aan Lid #{LidNummer} op {UitleenDatum:dd/MM/yyyy}";
    }
}
