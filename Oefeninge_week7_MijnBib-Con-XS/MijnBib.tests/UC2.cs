using Mijnbib.Controllers;
using Mijnbib.Models;
using Mijnbib.Repositories;
using NUnit.Framework;

namespace MijnBib.tests;

/// <summary>
/// Use case test voor Use Case 2: Uitlenen via Controller
/// Test de volledige flow van aanmelden en uitlenen zoals beschreven in use case 2, dat is inclusief uc 1 en 4.
/// </summary>
[TestFixture]
public class UC2Tests
{
    private InMemoryDataRepository? _repository;
    private MijnbibController? _controller;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryDataRepository(); // we gebruiken de in-memory repository voor tests
        _controller = new MijnbibController(_repository);
    }

    /// <summary>
    /// Test de happy flow van use case 2
    /// </summary>
    [Test]
    public void UC2_UitlenenWerken_VolledigeFlow()
    {
        // Use case 1, stap 1: Persoon biedt lidkaart aan
        int lidNummer = 1;  // dit is input van de gebruiker

        // ...

    }

    /// <summary>
    /// Test use case 1 uitzondering 3.1: Systeem herkent de gebruiker niet
    /// </summary>
    [Test]
    public void UC1_AanmeldenLid_OngeldigLidNummer()
    {
      
    }



 //...

}
