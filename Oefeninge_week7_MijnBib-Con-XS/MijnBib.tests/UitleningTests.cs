using Mijnbib.Models;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Unit tests voor Uitlening model
/// </summary>
[TestFixture]
public class UitleningTests
{
    [Test]
    public void VerwachteInleverDatum_Returns21DaysAfterUitleenDatum()
    {
        DateTime uitleenDatum = new DateTime(2024, 1, 1);
        Uitlening uitlening = new Uitlening
        {
            LidNummer = 1,
            WerkNr = 101,
            UitleenDatum = uitleenDatum,
            InleverDatum = null
        };

        DateTime verwacht = uitlening.VerwachteInleverDatum;

        Assert.That(verwacht, Is.EqualTo(new DateTime(2024, 1, 22)));
    }


    [Test]
    public void ToString_ReturnsCorrectFormat()
    {
        DateTime uitleenDatum = new DateTime(2024, 1, 15);
        Uitlening uitlening = new Uitlening
        {
            UitleningId = 1,
            LidNummer = 1,
            WerkNr = 101,
            UitleenDatum = uitleenDatum,
            InleverDatum = null
        };

        string result = uitlening.ToString();

        Assert.That(result, Is.EqualTo("Uitlening #1 - Werk #101 aan Lid #1 op 15/01/2024"));
    }

}
