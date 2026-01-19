using Mijnbib.Controllers;
using Mijnbib.Models;
using Mijnbib.Repositories;

namespace MijnBib_Con_XS;

/// <summary>
/// Console interface voor mijnbib
/// Use case 2: Uitlenen werken
/// </summary>
internal class Program
{
    private static MijnbibController? _controller;

    static void Main(string[] args)
    {
        InitializeController();
        ToonStartMenu();
    }

    /// <summary>
    /// Initialiseer controller
    /// </summary>
    private static void InitializeController()
    {
        InMemoryDataRepository repository = new InMemoryDataRepository();
        _controller = new MijnbibController(repository);
    }

    /// <summary>
    /// Use case 2, stap 1: Toon het startmenu
    /// </summary>
    private static void ToonStartMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mijnbib - Zelfbediening ===");
            Console.WriteLine();
            Console.WriteLine("1. Uitlenen");
            Console.WriteLine("2. Inleveren");
            Console.WriteLine("3. Afsluiten");
            Console.WriteLine();
            Console.Write("Kies een optie: ");

            string? keuze = Console.ReadLine();

            switch (keuze)
            {
                case "1":
                    UitlenenFlow();
                    break;
                case "2":
                    ToonInleverenNietGeimplementeerd();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze. Druk op een toets om opnieuw te proberen.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    /// <summary>
    /// Use case 2: Uitlenen flow
    /// </summary>
    private static void UitlenenFlow()
    {
        if (!AanmeldenLid())
        {
            return;
        }

        ToonUitleenScherm();
    }

    /// <summary>
    /// Use case 1: Aanmelden lid
    /// </summary>
    private static bool AanmeldenLid()
    {
        Console.WriteLine("=== Aanmelden ===");
        Console.WriteLine();
        Console.Write("Voer uw lidkaartnummer in: ");

        string? input = Console.ReadLine();
        if (int.TryParse(input, out int lidNummer))
        {
            bool success = _controller!.AanmeldenLid(lidNummer);
            if (success)
            {
                Lidkaart? lidkaart = _controller.GetHuidigLid();
                Console.WriteLine($"OK - Welkom {lidkaart!.LidNaam}!");
                return true;
            }
        }

        Console.WriteLine("Niet OK - Lidkaart niet herkend.");
        Console.ReadKey();
        return false;
    }

    /// <summary>
    /// Use case 2, stap 4: Toon uitleenscherm
    /// </summary>
    private static void ToonUitleenScherm()
    {
        while (true)
        {
            Console.WriteLine("=== Uitlenen ===");
            Console.WriteLine();
            
            Lidkaart? huidigLid = _controller!.GetHuidigLid();
            Console.WriteLine($"Ingelogd als: {huidigLid!.LidNaam}");
            Console.WriteLine($"Open uitleningen: {_controller.GetAantalOpenUitleningen()}");
            Console.WriteLine();

            if (!_controller.HuidigLidMagUitlenen())
            {
                Console.WriteLine("U heeft het maximum aantal open uitleningen bereikt.");
                Console.WriteLine();
                Console.WriteLine("Druk op een toets om terug te keren...");
                Console.ReadKey();
                _controller.BeeindigSessie();
                return;
            }

            Console.Write("Voer werknummer in (of 0 om te beëindigen): ");

            string? input = Console.ReadLine();
            if (input == "0")
            {
                _controller.BeeindigSessie();
                return;
            }

            if (int.TryParse(input, out int werkNr))
            {
                RegistreerUitlening(werkNr);
            }
            else
            {
                Console.WriteLine("Ongeldig werknummer.");
            }
        }
    }

    /// <summary>
    /// Use case 2, stap 7: Registreer de ontlening
    /// </summary>
    private static void RegistreerUitlening(int werkNr)
    {
        DateTime uitleenDatum = DateTime.Today;
        bool success = _controller!.RegistreerUitlening(werkNr, uitleenDatum);

        if (success)
        {
            Werk? werk = _controller.GetWerk(werkNr);
            if (werk != null)
            {
                Uitlening? uitlening = _controller.GetLaatsteUitlening(werk);
                if (uitlening != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Werk '{werk.Naam}' succesvol uitgeleend.");
                    Console.WriteLine($"Te inleveren op: {uitlening.VerwachteInleverDatum:dd/MM/yyyy}");
                    Console.WriteLine();

                }
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Uitlening mislukt. Werk niet gevonden of reeds uitgeleend.");
            Console.WriteLine();

        }
    }

    /// <summary>
    /// Requirement Req11: Mijnbib verontschuldigt zich bij het lid dat inleveren nog niet mogelijk is
    /// </summary>
    private static void ToonInleverenNietGeimplementeerd()
    {
        Console.WriteLine("=== Inleveren ===");
        Console.WriteLine();
        Console.WriteLine("Het spijt ons, inleveren is nog niet geïmplementeerd.");
        Console.WriteLine();
        Console.WriteLine("Druk op een toets om terug te keren...");
        Console.ReadKey();
    }
}


