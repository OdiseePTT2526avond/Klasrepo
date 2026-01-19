using Mijnbib.Models;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor Lidkaart model
/// </summary>
[TestFixture]
public class LidkaartTests
{
    [Test]
    public void AantalOpenUitleningen_GeenUitleningen_Returns0()
    {
        Lidkaart lidkaart = new Lidkaart { LidNummer = 1, LidNaam = "Test" };

        int aantal = lidkaart.AantalOpenUitleningen;

        Assert.That(aantal, Is.EqualTo(0));
    }

    [Test]
    public void AantalOpenUitleningen_MetOpenUitleningen_ReturnsCorrectCount()
    {
        Lidkaart lidkaart = new Lidkaart { LidNummer = 1, LidNaam = "Test" };
        lidkaart.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 101, UitleenDatum = DateTime.Today, InleverDatum = null });
        lidkaart.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 102, UitleenDatum = DateTime.Today, InleverDatum = null });

        int aantal = lidkaart.AantalOpenUitleningen;

        Assert.That(aantal, Is.EqualTo(2));
    }

    [Test]
    public void AantalOpenUitleningen_MetGeslotenUitleningen_ReturnsOnlyOpen()
    {
        Lidkaart lidkaart = new Lidkaart { LidNummer = 1, LidNaam = "Test" };
        lidkaart.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 101, UitleenDatum = DateTime.Today, InleverDatum = null });
        lidkaart.Uitleningen.Add(new Uitlening { LidNummer = 1, WerkNr = 102, UitleenDatum = DateTime.Today, InleverDatum = DateTime.Today });

        int aantal = lidkaart.AantalOpenUitleningen;

        Assert.That(aantal, Is.EqualTo(1));
    }


    [Test]
    public void ToString_ReturnsCorrectFormat()
    {
        Lidkaart lidkaart = new Lidkaart { LidNummer = 1, LidNaam = "Jan Jansen" };

        string result = lidkaart.ToString();

        Assert.That(result, Is.EqualTo("Jan Jansen (#1)"));
    }
}
