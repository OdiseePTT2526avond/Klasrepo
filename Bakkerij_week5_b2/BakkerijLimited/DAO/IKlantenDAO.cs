using BakkerijLimited.Models;

namespace BakkerijLimited.DAO
{
    public interface IKlantenDAO
    {
        Klant Create(Klant klant);
        Klant? GetById(int id);
        Klant? GetByNaam(string naam);
    }
}
