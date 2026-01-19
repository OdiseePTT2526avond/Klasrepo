using Mijnbib.Models;
using Mijnbib.Repositories;
using Mijnbib.Services;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor LidkaartService
/// </summary>
[TestFixture]
public class LidkaartServiceTests
{
    private InMemoryDataRepository? _repository;
    private LidkaartService? _service;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryDataRepository();
        _service = new LidkaartService(_repository);
    }

    [Test]
    public void ValideerLidkaart_GeldigLidNummer_ReturnsLidkaart()
    {
        int lidNummer = 1;

        Lidkaart? lidkaart = _service!.ValideerLidkaart(lidNummer);

        Assert.That(lidkaart, Is.Not.Null);
        Assert.That(lidkaart!.LidNummer, Is.EqualTo(lidNummer));
        Assert.That(lidkaart.LidNaam, Is.EqualTo("Jan Jansen"));
    }

    [Test]
    public void ValideerLidkaart_OngeldigLidNummer_ReturnsNull()
    {
        int ongeldigLidNummer = 999;

        Lidkaart? lidkaart = _service!.ValideerLidkaart(ongeldigLidNummer);

        Assert.That(lidkaart, Is.Null);
    }

    //Probleem: we gaan uit van de vaste data in InMemoryDataRepository. 
    // Dat mag niet en we moeten de service testen door de repository te mocken. Maak een double voor de repository.
    [Test]
    public void ValideerLidkaart_AlleLidkaarten_WordenGevonden()
    {
        Lidkaart? lid1 = _service!.ValideerLidkaart(1);
        Lidkaart? lid2 = _service.ValideerLidkaart(2);
        Lidkaart? lid3 = _service.ValideerLidkaart(3);

        Assert.That(lid1, Is.Not.Null);
        Assert.That(lid2, Is.Not.Null);
        Assert.That(lid3, Is.Not.Null);
        Assert.That(lid1!.LidNaam, Is.EqualTo("Jan Jansen"));
        Assert.That(lid2!.LidNaam, Is.EqualTo("Piet Pieters"));
//        Assert.That(lid3!.LidNaam, Is.EqualTo("Marie Maes"));
    }
}
