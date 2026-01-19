using Mijnbib.Models;
using Mijnbib.Repositories;

namespace Mijnbib.Services;

/// <summary>
/// Service voor lidkaart validatie
/// Requirement Req03: Mijnbib kan bepalen of een lidkaart geldig is of niet
/// </summary>
public class LidkaartService
{
    private readonly InMemoryDataRepository _repository;

    public LidkaartService(InMemoryDataRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Zoekt en retourneert een geldige Lidkaart op basis van het lidNummer
    /// Requirement Req02: Mijnbib kent alle geldige lidkaarten
    /// Requirement Req03: Mijnbib kan bepalen of een lidkaart geldig is of niet
    /// </summary>
    /// <param name="lidNummer">Lidkaartnummer</param>
    /// <returns>De geldige Lidkaart indien gevonden, anders null</returns>
    public Lidkaart? ValideerLidkaart(int lidNummer)
    {
        return _repository.FindLidkaart(lidNummer);
    }

}
