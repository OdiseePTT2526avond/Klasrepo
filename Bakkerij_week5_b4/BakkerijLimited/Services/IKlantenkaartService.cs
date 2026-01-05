
using BakkerijLimited.Models;

namespace BakkerijLimited.Services
{
    public interface IKlantenkaartService
    {
        Klantenkaart MaakKlantenkaart(Klant klant);
        Klantenkaart? ZoekKlantenkaart(int nummer);
        void UpdateKlantenkaart(Klantenkaart kaart);
    }
}
