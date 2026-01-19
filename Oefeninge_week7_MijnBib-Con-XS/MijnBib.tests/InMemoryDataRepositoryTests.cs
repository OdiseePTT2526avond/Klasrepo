using Mijnbib.Models;
using Mijnbib.Repositories;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor InMemoryDataRepository
/// </summary>
[TestFixture]
public class InMemoryDataRepositoryTests
{
    private InMemoryDataRepository? _repository;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryDataRepository();
    }

    [Test]
    public void FindLidkaart_GeldigLidNummer_ReturnsLidkaart()
    {
        int lidNummer = 1;

        Lidkaart? lidkaart = _repository!.FindLidkaart(lidNummer);

        Assert.That(lidkaart, Is.Not.Null);
        Assert.That(lidkaart!.LidNummer, Is.EqualTo(lidNummer));
    }

    [Test]
    public void FindLidkaart_OngeldigLidNummer_ReturnsNull()
    {
        int ongeldigLidNummer = 999;

        Lidkaart? lidkaart = _repository!.FindLidkaart(ongeldigLidNummer);

        Assert.That(lidkaart, Is.Null);
    }

    [Test]
    public void FindWerk_GeldigWerkNr_ReturnsWerk()
    {
        int werkNr = 101;

        Werk? werk = _repository!.FindWerk(werkNr);

        Assert.That(werk, Is.Not.Null);
        Assert.That(werk!.WerkNr, Is.EqualTo(werkNr));
    }

    [Test]
    public void FindWerk_OngeldigWerkNr_ReturnsNull()
    {
        int ongeldigWerkNr = 999;

        Werk? werk = _repository!.FindWerk(ongeldigWerkNr);

        Assert.That(werk, Is.Null);
    }

    [Test]
    public void AddUitlening_VoegtUitleningToe()
    {
        Uitlening uitlening = new Uitlening
        {
            LidNummer = 1,
            WerkNr = 101,
            UitleenDatum = DateTime.Today,
            InleverDatum = null
        };

        _repository!.AddUitlening(uitlening);

        Assert.That(uitlening.UitleningId, Is.EqualTo(1));  
        Assert.That(_repository.GetAllUitleningen().Count(), Is.EqualTo(1));
    }

    [Test]
    public void AddUitlening_IncrementeerUitleningId()
    {
        Uitlening uitlening1 = new Uitlening { LidNummer = 1, WerkNr = 101, UitleenDatum = DateTime.Today };
        Uitlening uitlening2 = new Uitlening { LidNummer = 2, WerkNr = 102, UitleenDatum = DateTime.Today };

        _repository!.AddUitlening(uitlening1);
        _repository.AddUitlening(uitlening2);

        Assert.That(uitlening2.UitleningId, Is.GreaterThan(uitlening1.UitleningId));
    }

    [Test]
    public void GetAllLidkaarten_ReturnsAllLidkaarten()
    {
        IEnumerable<Lidkaart> lidkaarten = _repository!.GetAllLidkaarten();

        Assert.That(lidkaarten.Count(), Is.EqualTo(3));
    }

    [Test]
    public void GetAllWerken_ReturnsAllWerken()
    {
        IEnumerable<Werk> werken = _repository!.GetAllWerken();

        Assert.That(werken.Count(), Is.EqualTo(5));
    }

}
