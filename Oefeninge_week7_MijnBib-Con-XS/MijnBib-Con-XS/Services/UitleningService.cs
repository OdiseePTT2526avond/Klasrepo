using Mijnbib.Models;
using Mijnbib.Repositories;

namespace Mijnbib.Services;

/// <summary>
/// Service voor uitlening beheersoperaties
/// Bevat bedrijfslogica voor het uitlenen en inleveren van werken
/// </summary>
public class UitleningService
{
    private readonly InMemoryDataRepository _repository;

    public UitleningService(InMemoryDataRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Probeert een nieuwe uitlening aan te maken voor een lid
    /// Requirement Req21: Mijnbib kan bepalen hoeveel extra uitleningen een lid mag doen
    /// Requirement Req22: Een lid mag maximaal 2 open uitleningen tegelijk hebben
    /// Requirement Req30: Een lid kan geen werk lenen dat momenteel is uitgeleend
    /// Requirement Req31: Mijnbib kan bepalen of een werk al is uitgeleend of niet
    /// Requirement Req32: Mijnbib kan een nieuwe uitlening onthouden
    /// </summary>
    /// <returns>Waar als de uitlening succesvol is aangemaakt, anders onwaar</returns>
    public bool LeenWerkUit(int lidNummer, int werkNr, DateTime uitleenDatum)
    {
        Lidkaart? lidkaart = _repository.FindLidkaart(lidNummer);
        if (lidkaart == null)
        {
            return false;
        }

        Werk? werk = _repository.FindWerk(werkNr);
        if (werk == null)
        {
            return false;
        }

        // Req30, Req31: Controleer of werk al is uitgeleend

        // Req32: Maak en onthoud de nieuwe uitlening
        Uitlening uitlening = new Uitlening
        {
            LidNummer = lidNummer,
            WerkNr = werkNr,
            UitleenDatum = uitleenDatum,
            InleverDatum = null
        };

        // Stel navigatie properties in
        uitlening.Lidkaart = lidkaart;
        uitlening.Werk = werk;

        // Voeg uitlening toe aan collecties
        lidkaart.Uitleningen.Add(uitlening);
        werk.Uitleningen.Add(uitlening);

        // Bewaar in repository
        _repository.AddUitlening(uitlening);

        return true;
    }

    /// <summary>
    /// Haalt alle open uitleningen op voor een lid
    /// Requirement Req20: Mijnbib kent alle uitleningen van elk lid
    /// </summary>
    public IEnumerable<Uitlening> GetOpenUitleningen(int lidNummer)
    {
        Lidkaart? lidkaart = _repository.FindLidkaart(lidNummer);
        return lidkaart?.Uitleningen.Where(u => u.InleverDatum == null) ?? Enumerable.Empty<Uitlening>();
    }

    /// <summary>
    /// Geeft de huidige uitlening van een werk terug, indien die bestaat
    /// </summary>
    /// <param name="werk">het werk.</param>
    /// <returns>de uitlening indien die bestaat anders null.</returns>
    public Uitlening? GetOpenUitlening(Werk werk)
    {
        return werk.Uitleningen.Where(u => u.InleverDatum == null).FirstOrDefault();
    }
}
