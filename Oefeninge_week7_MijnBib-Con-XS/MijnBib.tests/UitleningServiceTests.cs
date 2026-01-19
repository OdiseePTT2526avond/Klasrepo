using Mijnbib.Models;
using Mijnbib.Repositories;
using Mijnbib.Services;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor UitleningService
/// </summary>
[TestFixture]
public class UitleningServiceTests
{
    private InMemoryDataRepository _repository;
    private UitleningService _service;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryDataRepository();
        _service = new UitleningService(repository: _repository);
    }

    [Test]
    public void LeenWerkUit_GeldigLidEnWerk_ReturnsTrue()
    {
        int lidNummer = 1;
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;

        bool result = _service!.LeenWerkUit(lidNummer, werkNr, uitleenDatum);

        Assert.That(result, Is.True);
    }

    [Test]
    public void LeenWerkUit_OngeldigLid_ReturnsFalse()
    {
        int ongeldigLidNummer = 999;
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;

        bool result = _service!.LeenWerkUit(ongeldigLidNummer, werkNr, uitleenDatum);

        Assert.That(result, Is.False);
    }

    [Test]
    public void LeenWerkUit_OngeldigWerk_ReturnsFalse()
    {
        int lidNummer = 1;
        int ongeldigWerkNr = 999;
        DateTime uitleenDatum = DateTime.Today;

        bool result = _service!.LeenWerkUit(lidNummer, ongeldigWerkNr, uitleenDatum);

        Assert.That(result, Is.False);
    }



    [Test]
    public void LeenWerkUit_WhenSuccess_PastLidkaartEnWerkAan()
    {
        int lidNummer = 1;
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;

        Lidkaart? lidkaart = _repository!.FindLidkaart(lidNummer);
        Assert.That(lidkaart!.AantalOpenUitleningen, Is.EqualTo(0));
        Werk? werk = _repository!.FindWerk(werkNr);
        Assert.That(werk!.IsUitgeleend, Is.False);

        _service!.LeenWerkUit(lidNummer, werkNr, uitleenDatum);

        Assert.That(lidkaart.AantalOpenUitleningen, Is.EqualTo(1));
        Assert.That(werk.IsUitgeleend, Is.True);
    }

    [Test]
    public void GetOpenUitleningen_GeenUitleningen_ReturnsEmpty()
    {
        int lidNummer = 1;

        IEnumerable<Uitlening> uitleningen = _service!.GetOpenUitleningen(lidNummer);

        Assert.That(uitleningen, Is.Empty);
    }

    [Test]
    public void GetOpenUitleningen_MetUitleningen_ReturnsUitleningen()
    {
        int lidNummer = 1;
        DateTime uitleenDatum = DateTime.Today;
        _service!.LeenWerkUit(lidNummer, 101, uitleenDatum);
        _service.LeenWerkUit(lidNummer, 102, uitleenDatum);

        IEnumerable<Uitlening> uitleningen = _service.GetOpenUitleningen(lidNummer);

        Assert.That(uitleningen.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetOpenUitleningen_OngeldigLid_ReturnsEmpty()
    {
        int ongeldigLidNummer = 999;

        IEnumerable<Uitlening> uitleningen = _service!.GetOpenUitleningen(ongeldigLidNummer);

        Assert.That(uitleningen, Is.Empty);
    }

    [Test]
    public void GetOpenUitlening_WerkZonderUitleningen_ReturnsNull()
    {
        Werk? werk = _repository!.FindWerk(101);
        Assert.That(werk, Is.Not.Null);

        Uitlening? uitlening = _service!.GetOpenUitlening(werk!);

        Assert.That(uitlening, Is.Null);
    }

    [Test]
    public void GetOpenUitlening_WerkMetOpenUitlening_ReturnsUitlening()
    {
        int lidNummer = 1;
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;
        _service!.LeenWerkUit(lidNummer, werkNr, uitleenDatum);

        Werk? werk = _repository!.FindWerk(werkNr);
        Assert.That(werk, Is.Not.Null);

        Uitlening? uitlening = _service.GetOpenUitlening(werk!);

        Assert.That(uitlening, Is.Not.Null);
        Assert.That(uitlening!.WerkNr, Is.EqualTo(werkNr));
        Assert.That(uitlening.InleverDatum, Is.Null);
    }

    [Test]
    public void GetOpenUitlening_WerkMetGeslotenUitlening_ReturnsNull()
    {
        int lidNummer = 1;
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today.AddDays(-10);
        _service!.LeenWerkUit(lidNummer, werkNr, uitleenDatum);

        Werk? werk = _repository!.FindWerk(werkNr);
        Assert.That(werk, Is.Not.Null);

        Uitlening? openUitlening = werk!.Uitleningen.FirstOrDefault();
        Assert.That(openUitlening, Is.Not.Null);
        openUitlening!.InleverDatum = DateTime.Today;
        //ACT
        Uitlening? result = _service.GetOpenUitlening(werk);

        Assert.That(result, Is.Null);
    }

}
