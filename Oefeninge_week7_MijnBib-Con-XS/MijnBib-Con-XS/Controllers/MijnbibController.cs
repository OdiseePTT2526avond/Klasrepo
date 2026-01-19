using Mijnbib.Models;
using Mijnbib.Repositories;
using Mijnbib.Services;

namespace Mijnbib.Controllers;

/// <summary>
/// Controller voor mijnbib logica
/// Scheidt bedrijfslogica van presentatielaag
/// </summary>
public class MijnbibController
{
    private readonly InMemoryDataRepository _repository;
    private readonly LidkaartService _lidkaartService;
    private readonly UitleningService _uitleningService;
    private Lidkaart? _huidigLid;

    public MijnbibController(InMemoryDataRepository repository)
    {
        _repository = repository;
        _lidkaartService = new LidkaartService(_repository);
        _uitleningService = new UitleningService(_repository);
    }

    /// <summary>
    /// Haalt het huidige ingelogde lid op
    /// </summary>
    public Lidkaart? GetHuidigLid()
    {
        return _huidigLid;
    }

    /// <summary>
    /// Use case 1: Aanmelden lid
    /// </summary>
    /// <returns>true als aanmelden succesvol is</returns>
    public bool AanmeldenLid(int lidNummer)
    {
        Lidkaart? lidkaart = _lidkaartService.ValideerLidkaart(lidNummer);
        if (lidkaart != null)
        {
            _huidigLid = lidkaart;
            return true;
        }

        _huidigLid = null;
        return false;
    }

    /// <summary>
    /// Controleert of het huidige lid mag uitlenen
    /// </summary>
    public bool HuidigLidMagUitlenen()
    {
        return true;
        //return _huidigLid?.MagUitlenen ?? false;
    }

    /// <summary>
    /// Haalt het aantal open uitleningen van het huidige lid op
    /// </summary>
    public int GetAantalOpenUitleningen()
    {
        return _huidigLid!.AantalOpenUitleningen;
    }

    /// <summary>
    /// Use case 2: Registreer een uitlening
    /// </summary>
    /// <returns>Waar als uitlening succesvol is</returns>
    public bool RegistreerUitlening(int werkNr, DateTime uitleenDatum)
    {
        if (_huidigLid == null)
        {
            return false;
        }
        return _uitleningService.LeenWerkUit(_huidigLid.LidNummer, werkNr, uitleenDatum);
    }

    /// <summary>
    /// Haalt werk op basis van werknummer
    /// </summary>
    public Werk? GetWerk(int werkNr)
    {
        return _repository.FindWerk(werkNr);
    }

    /// <summary>
    /// Haalt de laatste uitlening van een werk voor het huidige lid
    /// </summary>
    public Uitlening? GetLaatsteUitlening(Werk werk)
    {
        return _uitleningService.GetOpenUitlening(werk);
        //return _huidigLid?.Uitleningen.FirstOrDefault(u => u.WerkNr == werkNr && u.InleverDatum == null);
    }

    /// <summary>
    /// Use case 4: Beëindigen sessie
    /// </summary>
    public void BeeindigSessie()
    {
        _huidigLid = null;
    }

}
