
using BakkerijLimited.Models;

namespace BakkerijLimited.Services
{
    public interface IKlantenService
    {
        Klant? HaalKlantOp(int id);
        Klant? HaalKlantOp(string naam);
        Klant MaakKlant(string naam);
    }
}
