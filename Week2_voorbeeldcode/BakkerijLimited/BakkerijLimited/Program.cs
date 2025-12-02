using BakkerijLimited.Domain;
using BakkerijLimited.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Bakkerij bakkerij = new Bakkerij();
        bool programmaDraait = true;

        while (programmaDraait)
        {
            Console.Clear();
            string? klantNaam = VraagKlantNaam();

            if (klantNaam == null)
                break;

            Klant bezoeker = new Klant(klantNaam);

            // REQ0005 – De klant kan met klantenkaartnummer 0 aangeven dat die een klantenkaart wenst.
            // REQ0004 – Bakkerij kan nagaan of klantenkaart met bepaald nummer bestaat en opzoeken
            // REQ0006 – Een nieuwe klantenkaart aanmaken en toevoegen aan de repo
            // REQ0007 – De klant kan met klantenkaartnummer 9999 aangeven dat die geen klantenkaart wenst.
            HandleCardSelection(bakkerij, bezoeker);

            // REQ0001 — laat de bezoeker bestellingen plaatsen (bestellingen worden niet automatisch op kaarten bijgeschreven)
            LaatKlantBestellingenPlaatsen(bakkerij, bezoeker);

            Console.WriteLine();
            Console.Write("Volgende klant? (j/n): ");
            programmaDraait = Console.ReadLine()?.Trim().ToLower() == "j";
        }

        Console.WriteLine("\nProgramma afgesloten. Tot ziens!");
    }

    private static void HandleCardSelection(Bakkerij bakkerij, Klant bezoeker)
    {
        // Use explicit numeric sentinel 9999 to continue without a card
        int? eerste = PromptForCardNumber("Heeft u een klantenkaart? Geef het nummer in, voer 0 in om een nieuwe klantenkaart aan te vragen, of voer 9999 in om zonder kaart verder te gaan: ");
        if (!eerste.HasValue)
            return;

        if (eerste.Value == 0)
        {
            // REQ0006 – maak nieuwe kaart aan voor bezoeker
            MaakEnToonNieuweKlantenkaart(bakkerij, bezoeker);
            return;
        }

        // Hier hebben we een positief kaartnummer waar we op moeten zoeken
        SelectOrCreateCard(bakkerij, bezoeker, eerste.Value);
    }

    private static void SelectOrCreateCard(Bakkerij bakkerij, Klant bezoeker, int startNummer)
    {
        int huidigNummer = startNummer;

        while (true)
        {
            var gevonden = bakkerij.ZoekEnSelecteerKlantenkaart(huidigNummer);
            if (gevonden is null)
            {
                Console.WriteLine($"Geen klantenkaart gevonden met nummer {huidigNummer}.");
            }
            else
            {
                Console.WriteLine($"Klantenkaart #{gevonden.KlantenkaartNummer} gevonden. Kaart hoort bij: {gevonden.Klant.Naam}");

                if (string.Equals(gevonden.Klant.Naam, bezoeker.Naam, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Naam komt overeen; kaart geselecteerd.");
                    return;
                }

                if (PromptYesNo($"De naam op de kaart ({gevonden.Klant.Naam}) verschilt van de bezoeker ({bezoeker.Naam}). Wilt u deze kaart gebruiken?"))
                {
                    Console.WriteLine("Kaart geselecteerd.");
                    return;
                }
            }

            if (!PromptYesNo("Wilt u een ander kaartnummer invoeren?"))
            {
                // geen kaart gebruiken -> deselecteer
                bakkerij.ZoekEnSelecteerKlantenkaart(-1);
                return;
            }

            int? next = PromptForCardNumber("Geef een ander kaartnummer (0 voor nieuwe kaart, 9999 om geen kaart te gebruiken): ");
            if (!next.HasValue)
            {
                bakkerij.ZoekEnSelecteerKlantenkaart(-1);
                return;
            }

            if (next.Value == 0)
            {
                MaakEnToonNieuweKlantenkaart(bakkerij, bezoeker);
                return;
            }

            huidigNummer = next.Value;
        }
    }

    private static int? PromptForCardNumber(string? prompt = "Geef het kaartnummer (0 voor nieuwe kaart, 9999 om te stoppen): ")
    {
        // Loop until a valid integer is entered or the sentinel 9999 is entered to stop.
        while (true)
        {
            Console.Write(prompt);
            string? line = Console.ReadLine()?.Trim();

            // REQ0007 – De klant kan met klantenkaartnummer 9999 aangeven dat die geen klantenkaart wenst.
            if (line == "9999")
                return null; // sentinel: proceed without a card

            if (int.TryParse(line, out int num))
                return num;

            Console.WriteLine("Ongeldige invoer. Voer een nummer in of 9999 om zonder kaart verder te gaan.");
        }
    }

    private static bool PromptYesNo(string vraag)
    {
        Console.Write($"{vraag} (j/n): ");
        return Console.ReadLine()?.Trim().ToLower() == "j";
    }

    private static string? VraagKlantNaam()
    {
        Console.Write("Naam van de klant (of leeg laten om te stoppen): ");
        string? naam = Console.ReadLine();
        return string.IsNullOrWhiteSpace(naam) ? null : naam.Trim();
    }

    private static Brood? VraagBroodKeuze()
    {
        Console.WriteLine("Kies broodtype:");
        Console.WriteLine($"1. {Bakkerij.WitBrood.BroodSoort}  (€{Bakkerij.WitBrood.Prijs})");
        Console.WriteLine($"2. {Bakkerij.BruinBrood.BroodSoort} (€{Bakkerij.BruinBrood.Prijs})");
        Console.Write("Uw keuze: ");

        return Console.ReadLine() switch
        {
            "1" => Bakkerij.WitBrood,
            "2" => Bakkerij.BruinBrood,
            _ => null
        };
    }

    private static int VraagAantal()
    {
        Console.Write("Aantal broden: ");
        return int.TryParse(Console.ReadLine(), out int aantal) && aantal > 0
            ? aantal
            : -1;
    }

    // ---------------------------------------------------------
    // REQ0001: Klant kan een bestelling voor een aantal broden aanmaken
    // ---------------------------------------------------------
    private static void LaatKlantBestellingenPlaatsen(Bakkerij bakkerij, Klant klant)
    {
        bool klantBestelt = true;

        while (klantBestelt)
        {
            Console.WriteLine($"\nKlant {klant.Naam} plaatst een bestelling.");

            Brood? brood = VraagBroodKeuze();
            if (brood == null)
            {
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                continue;
            }

            int aantal = VraagAantal();
            if (aantal <= 0)
            {
                Console.WriteLine("Aantal ongeldig. Probeer opnieuw.");
                continue;
            }

            bakkerij.MaakBestelling(klant, brood, aantal);

            Console.WriteLine($"Bestelling geplaatst ({aantal} × {brood.BroodSoort}).");

            Console.Write("Nog een bestelling voor deze klant? (j/n): ");
            klantBestelt = Console.ReadLine()?.Trim().ToLower() == "j";
        }
    }

    // Helper to remove duplication when creating a new klantenkaart
    private static Klantenkaart MaakEnToonNieuweKlantenkaart(Bakkerij bakkerij, Klant bezoeker)
    {
        bakkerij.Klant = bezoeker;
        var nieuweKaart = bakkerij.MaakKlantenkaart();
        Console.WriteLine($"Nieuwe klantenkaart aangemaakt: #{nieuweKaart.KlantenkaartNummer} voor {nieuweKaart.Klant.Naam}");
        return nieuweKaart;
    }
}
