
using BakkerijLimited.DAO;
using BakkerijLimited.Models;

namespace BakkerijLimited.Services
{
    public class KlantenkaartService : IKlantenkaartService
    {
        private readonly IKlantenkaartenDAO _dao;

        public KlantenkaartService(IKlantenkaartenDAO dao)
        {
            _dao = dao;
        }

        public Klantenkaart MaakKlantenkaart(Klant klant)
        {
            return _dao.Create(klant);
        }

        public Klantenkaart? ZoekKlantenkaart(int nummer)
        {
            return _dao.GetByNummer(nummer);
        }

        public void UpdateKlantenkaart(Klantenkaart? kaart)
        {
            if (kaart is null)
                throw new ArgumentNullException(nameof(kaart), 
                    "Klantenkaart mag niet null zijn bij update.");
            _dao.Update(kaart);
        }
    }
}
