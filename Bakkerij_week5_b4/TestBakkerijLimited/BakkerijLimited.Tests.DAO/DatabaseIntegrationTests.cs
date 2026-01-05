using BakkerijLimited.DAO;
using BakkerijLimited.Domain;
using BakkerijLimited.Services;
using BakkerijLimited.Models;

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
                new KlantenService(new KlantenDAO()),
                new KlantenkaartService(new KlantenkaartenDAO())
            );

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

        [Test]
        public void VolledigeFlow_Klant_Klantenkaart_Brood()
        {
            var klant = _bakkerij.RegistreerNieuweKlant("Test_" + System.Guid.NewGuid());
            var kaart = _bakkerij.MaakKlantenkaart();

            _bakkerij.MaakBestelling(klant, Bakkerij.WitBrood, 7);
            _bakkerij.VoegBestellingToeAanKlantenkaart();

            var dao = new KlantenkaartenDAO();
            var opgehaald = dao.GetByNummer(kaart.KlantenkaartNummer);

            Assert.That(opgehaald!.AantalBroden, Is.EqualTo(7));
        }

    }
}
