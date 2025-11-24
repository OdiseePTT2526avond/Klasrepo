using OdiseeAdmin2.Models;

using System;

while (true)
{
    Console.WriteLine("Welkom bij Odisee administratie");
    Console.WriteLine("1) Voeg docent toe");
    Console.WriteLine("2) Voeg student toe");
    Console.WriteLine("3) Voeg score toe");
    Console.WriteLine("4) Toon alle docenten");
    Console.WriteLine("5) Toon alle studenten");
    Console.WriteLine("6) Toon alle scores");
    Console.WriteLine("x) Sluit");
    Console.Write("> ");

    var keuze = Console.ReadLine();
    if (keuze?.ToLower() == "x") break;

    switch (keuze)
    {
        case "1":
            Console.Write("Voornaam achternaam: ");
            var d = (Console.ReadLine() ?? "").Split(' ');
            if (d.Length >= 2) new Docent(d[0], d[1]);
            break;

        case "2":
            Console.Write("Voornaam achternaam: ");
            var s = (Console.ReadLine() ?? "").Split(' ');
            if (s.Length >= 2) new Student(s[0], s[1]);
            break;

        case "3":
            Console.Write("StudentNaam Vak Score: ");
            var sc = (Console.ReadLine() ?? "").Split(' ');
            if (sc.Length >= 3 && int.TryParse(sc[2], out var val))
                new Score(sc[0], sc[1], val);
            break;

        case "4":
            Console.WriteLine("Docenten:");
            foreach (var doc in Docent.Docenten)
                Console.WriteLine($"- {doc}");
            break;

        case "5":
            Console.WriteLine("Studenten:");
            foreach (var stud in Student.Studenten)
                Console.WriteLine($"- {stud}");
            break;

        case "6":
            Console.WriteLine("Scores:");
            foreach (var score in Score.Scores)
                Console.WriteLine($"- {score}");
            break;

        default:
            Console.WriteLine("Onbekende keuze.");
            break;
    }

    Console.WriteLine();
}
