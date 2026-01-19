using Mijnbib.Models;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor Werk model
/// </summary>
[TestFixture]
public class WerkTests
{
    [Test]
    public void IsUitgeleend_GeenUitleningen_ReturnsFalse()
    {
        Werk werk = new Werk { WerkNr = 101, Naam = "Test Boek", Auteur = "Test Auteur" };

        bool isUitgeleend = werk.IsUitgeleend;

        Assert.That(isUitgeleend, Is.False);
    }

    [Test]
    public void IsUitgeleend_MetOpenUitlening_ReturnsTrue()
    {
        Werk werk = new Werk { WerkNr = 101, Naam = "Test Boek", Auteur = "Test Auteur" };
        werk.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 101, UitleenDatum = DateTime.Today, InleverDatum = null });

        bool isUitgeleend = werk.IsUitgeleend;

        Assert.That(isUitgeleend, Is.True);
    }

    [Test]
    public void IsUitgeleend_MetGeslotenUitlening_ReturnsFalse()
    {
        Werk werk = new Werk { WerkNr = 101, Naam = "Test Boek", Auteur = "Test Auteur" };
        werk.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 101, UitleenDatum = DateTime.Today, InleverDatum = DateTime.Today.AddDays(7) });

        bool isUitgeleend = werk.IsUitgeleend;

        Assert.That(isUitgeleend, Is.False);
    }

    [Test]
    public void IsUitgeleend_MetMeerdereUitleningen_ReturnsCorrectStatus()
    {
        Werk werk = new Werk { WerkNr = 101, Naam = "Test Boek", Auteur = "Test Auteur" };
        werk.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 101, UitleenDatum = DateTime.Today.AddDays(-14), InleverDatum = DateTime.Today.AddDays(-7) });
        werk.Uitleningen.Add(new Uitlening { LidNummer = 2, WerkNr = 101, UitleenDatum = DateTime.Today, InleverDatum = null });

        bool isUitgeleend = werk.IsUitgeleend;

        Assert.That(isUitgeleend, Is.True);
    }

    [Test]
    public void ToString_ReturnsCorrectFormat()
    {
        Werk werk = new Werk { WerkNr = 101, Naam = "De Aanslag", Auteur = "Harry Mulisch" };

        string result = werk.ToString();

        Assert.That(result, Is.EqualTo("De Aanslag - Harry Mulisch (#101)"));
    }
}
