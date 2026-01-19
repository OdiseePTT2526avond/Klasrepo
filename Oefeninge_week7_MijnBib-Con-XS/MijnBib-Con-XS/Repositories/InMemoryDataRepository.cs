using Mijnbib.Models;
using System.Collections.ObjectModel;

namespace Mijnbib.Repositories;

/// <summary>
/// In-memory repository voor het beheren van lidkaarten, werken en uitleningen
/// Requirement Req02: Mijnbib kent alle geldige lidkaarten
/// Requirement Req20: Mijnbib kent alle ontleningen van elk lid
/// </summary>
public class InMemoryDataRepository
{
    private readonly List<Lidkaart> _lidkaarten = new();
    private readonly List<Werk> _werken = new();
    private readonly List<Uitlening> _uitleningen = new();
    private int _nextUitleningId = 1;

    public InMemoryDataRepository()
    {
        InitializeData();
    }

    /// <summary>
    /// Initialiseert testdata //TODO : naar andere klasse verplaatsen
    /// </summary>
    private void InitializeData()
    {
        _lidkaarten.Add(new Lidkaart { LidNummer = 1, LidNaam = "Jan Jansen" });
        _lidkaarten.Add(new Lidkaart { LidNummer = 2, LidNaam = "Piet Pieters" });
        _lidkaarten.Add(new Lidkaart { LidNummer = 3, LidNaam = "Zakaria Zotara" });

        _werken.Add(new Werk { WerkNr = 101, Naam = "De Aanslag", Auteur = "Harry Mulisch" });
        _werken.Add(new Werk { WerkNr = 102, Naam = "Het Diner", Auteur = "Herman Koch" });
        _werken.Add(new Werk { WerkNr = 103, Naam = "De Ontdekking van de Hemel", Auteur = "Harry Mulisch" });
        _werken.Add(new Werk { WerkNr = 104, Naam = "Turks Fruit", Auteur = "Jan Wolkers" });
        _werken.Add(new Werk { WerkNr = 105, Naam = "De Avonden", Auteur = "Gerard Reve" });
    }

    /// <summary>
    /// Zoekt een lidkaart op basis van lidnummer
    /// Requirement Req02: Mijnbib kent alle geldige lidkaarten
    /// </summary>
    public Lidkaart? FindLidkaart(int lidNummer)
    {
        return _lidkaarten.FirstOrDefault(l => l.LidNummer == lidNummer);
    }

    /// <summary>
    /// Zoekt een werk op basis van werknummer
    /// </summary>
    public Werk? FindWerk(int werkNr)
    {
        return _werken.FirstOrDefault(w => w.WerkNr == werkNr);
    }

    /// <summary>
    /// Voegt een nieuwe uitlening toe aan de repository
    /// </summary>
    public void AddUitlening(Uitlening uitlening)
    {
        uitlening.UitleningId = _nextUitleningId++;
        _uitleningen.Add(uitlening);
    }

    /// <summary>
    /// Haalt alle lidkaarten op
    /// </summary>
    public IEnumerable<Lidkaart> GetAllLidkaarten()
    {
        return _lidkaarten;
    }

    /// <summary>
    /// Haalt alle werken op
    /// </summary>
    public IEnumerable<Werk> GetAllWerken()
    {
        return _werken;
    }

    /// <summary>
    /// Haalt alle uitleningen op
    /// </summary>
    public IEnumerable<Uitlening> GetAllUitleningen()
    {
        return _uitleningen;
    }
}
