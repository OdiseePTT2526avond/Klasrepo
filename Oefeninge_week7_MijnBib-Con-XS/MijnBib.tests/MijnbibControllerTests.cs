using Mijnbib.Controllers;
using Mijnbib.Models;
using Mijnbib.Repositories;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor MijnbibController
/// </summary>
[TestFixture]
public class MijnbibControllerTests
{
    private InMemoryDataRepository? _repository;
    private MijnbibController? _controller;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryDataRepository();
        _controller = new MijnbibController(_repository);
    }

    [Test]
    public void AanmeldenLid_GeldigLidNummer_ReturnsTrue()
    {
        int lidNummer = 1;

        bool result = _controller!.AanmeldenLid(lidNummer);

        Assert.That(result, Is.True);
        Assert.That(_controller.GetHuidigLid(), Is.Not.Null);
        Assert.That(_controller.GetHuidigLid()!.LidNummer, Is.EqualTo(lidNummer));
    }

    [Test]
    public void AanmeldenLid_OngeldigLidNummer_ReturnsFalse()
    {
        int ongeldigLidNummer = 999;

        bool result = _controller!.AanmeldenLid(ongeldigLidNummer);

        Assert.That(result, Is.False);
        Assert.That(_controller.GetHuidigLid(), Is.Null);
    }


    [Test]
    public void HuidigLidMagUitlenen_LidIngelogdZonderUitleningen_ReturnsTrue()
    {
        _controller!.AanmeldenLid(1);

        bool result = _controller.HuidigLidMagUitlenen();

        Assert.That(result, Is.True);
    }


    [Test]
    public void GetAantalOpenUitleningen_LidIngelogdZonderUitleningen_Returns0()
    {
        _controller!.AanmeldenLid(1);

        int result = _controller.GetAantalOpenUitleningen();

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void RegistreerUitlening_GeenLidIngelogd_ReturnsFalse()
    {
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;

        bool result = _controller!.RegistreerUitlening(werkNr, uitleenDatum);

        Assert.That(result, Is.False);
    }

    [Test]
    public void RegistreerUitlening_GeldigWerkEnLid_ReturnsTrue()
    {
        _controller!.AanmeldenLid(1);
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;

        bool result = _controller.RegistreerUitlening(werkNr, uitleenDatum);

        Assert.That(result, Is.True);
        Assert.That(_controller.GetAantalOpenUitleningen(), Is.EqualTo(1));
    }

    [Test]
    public void RegistreerUitlening_OngeldigWerk_ReturnsFalse()
    {
        _controller!.AanmeldenLid(1);
        int ongeldigWerkNr = 999;
        DateTime uitleenDatum = DateTime.Today;

        bool result = _controller.RegistreerUitlening(ongeldigWerkNr, uitleenDatum);

        Assert.That(result, Is.False);
        Assert.That(_controller.GetAantalOpenUitleningen(), Is.EqualTo(0));
    }

    [Test]
    public void GetWerk_GeldigWerkNr_ReturnsWerk()
    {
        int werkNr = 101;

        Werk? werk = _controller!.GetWerk(werkNr);

        Assert.That(werk, Is.Not.Null);
        Assert.That(werk!.WerkNr, Is.EqualTo(werkNr));
    }

    [Test]
    public void GetWerk_OngeldigWerkNr_ReturnsNull()
    {
        int ongeldigWerkNr = 999;

        Werk? werk = _controller!.GetWerk(ongeldigWerkNr);

        Assert.That(werk, Is.Null);
    }

    [Test]
    public void GetLaatsteUitlening_GeenLidIngelogd_ReturnsNull()
    {
        int werkNr = 101;
        Werk? werk = _controller!.GetWerk(werkNr);
        Assert.That(werk, Is.Not.Null);

        Uitlening? uitlening = _controller.GetLaatsteUitlening(werk!);

        Assert.That(uitlening, Is.Null);
    }

    [Test]
    public void GetLaatsteUitlening_NaUitlening_ReturnsUitlening()
    {
        _controller!.AanmeldenLid(1);
        int werkNr = 101;
        DateTime uitleenDatum = DateTime.Today;
        _controller.RegistreerUitlening(werkNr, uitleenDatum);

        Werk? werk = _controller.GetWerk(werkNr);
        Assert.That(werk, Is.Not.Null);
        Uitlening? uitlening = _controller.GetLaatsteUitlening(werk!);

        Assert.That(uitlening, Is.Not.Null);
        Assert.That(uitlening!.WerkNr, Is.EqualTo(werkNr));
        Assert.That(uitlening.InleverDatum, Is.Null);
    }

    [Test]
    public void BeeindigSessie_LidIngelogd_VerwijdertHuidigLid()
    {
        _controller!.AanmeldenLid(1);
        Assert.That(_controller.GetHuidigLid(), Is.Not.Null);

        _controller.BeeindigSessie();

        Assert.That(_controller.GetHuidigLid(), Is.Null);
    }

}
