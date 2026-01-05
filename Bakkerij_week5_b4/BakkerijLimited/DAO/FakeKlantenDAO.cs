using BakkerijLimited.DAO;
using BakkerijLimited.Models;

namespace BakkerijLimited.DAO
{
    public class FakeKlantenDAO : IKlantenDAO
    {
        private int _nextId = 1;
        private Klant? _laatsteKlant;

        public Klant Create(Klant klant)
        {
            klant.KlantId=(_nextId++);
            _laatsteKlant = klant;
            return klant;
        }

        public Klant? GetById(int id)
        {
            if (_laatsteKlant == null)
                return null;

            return _laatsteKlant.KlantId == id
                ? _laatsteKlant
                : null;
        }

        Klant? IKlantenDAO.GetByNaam(string naam)
        {
            return _laatsteKlant != null && _laatsteKlant.Naam == naam
                ? _laatsteKlant
                : null;
        }
    }
}
