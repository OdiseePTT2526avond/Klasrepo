using BakkerijLimited.DAO;
using BakkerijLimited.Domain;
using BakkerijLimited.Services;

namespace BakkerijLimited.Tests.DAO
{
    public class DatabaseIntegrationTests
    {
        private Bakkerij _bakkerij; 

        [SetUp]
        public void Setup()
        {
            // Arrange
            _bakkerij = new Bakkerij(
                              new KlantenService(
                                  new KlantenDAO()));
        }


        [Test]
        public void KanKlantAanmaken()
        {
            var naam = "Test_" + System.Guid.NewGuid();
            var klant = _bakkerij.RegistreerNieuweKlant(naam);

            Assert.That(klant.KlantId, Is.GreaterThan(0));
            Assert.That(klant.Naam, Is.EqualTo(naam));
        }

        [Test]
        public void KanKlantAanmakenEnOphalen()
        {
            var naam = "Test_" + System.Guid.NewGuid();
            var klant = _bakkerij.RegistreerNieuweKlant(naam);

            Assert.That(klant.KlantId, Is.GreaterThan(0));

            var opgehaald = _bakkerij.ZoekEnSelecteerKlant(klant.KlantId);
            Assert.That(opgehaald, Is.Not.Null);
            Assert.That(opgehaald!.Naam, Is.EqualTo(naam));
        }
    }
}
