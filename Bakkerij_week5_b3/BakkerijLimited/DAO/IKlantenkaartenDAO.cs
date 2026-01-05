
using BakkerijLimited.Models;

namespace BakkerijLimited.DAO
{
    public interface IKlantenkaartenDAO
    {
        Klantenkaart Create(Klant klant);
        Klantenkaart? GetByNummer(int nummer);
        void Update(Klantenkaart kaart);
    }
}
