
using BakkerijLimited.DAO;
using BakkerijLimited.Models;

namespace BakkerijLimited.Services
{
    public class KlantenService : IKlantenService
    {
        private readonly IKlantenDAO _dao;

        public KlantenService(IKlantenDAO dao)
        {
            _dao = dao;
        }

        public Klant MaakKlant(string naam)
        {
            return _dao.Create(new Klant(naam));
        }

        public Klant? HaalKlantOp(int id)
        {
            return _dao.GetById(id);
        }
        public Klant? HaalKlantOp(string naam)
        {
            return _dao.GetByNaam(naam);
        }
    }
}
