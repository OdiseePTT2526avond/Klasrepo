using System;
using System.Collections.Generic;

var docenten = new List<string[]>();   // elke entry = [id, naam, ...]
var studenten = new List<string[]>();   // idem
var scores = new List<string[]>();   // bv. [studentId, vak, score]

while (true)
{
    Console.WriteLine("Welkom bij Odisee administratie");
    Console.WriteLine("Welke taak wil je uitvoeren (geef het nummer in of x om af te sluiten)");
    Console.WriteLine("1) Voeg Docent toe");
    Console.WriteLine("2) Voeg Student toe");
    Console.WriteLine("3) Voeg score toe");
    Console.WriteLine("4) Print overzicht van alle docenten");
    Console.WriteLine("5) Print alle studenten en het aantal vakken waarvoor ze geslaagd zijn");
    Console.WriteLine("x) Sluit de applicatie");
    Console.Write("> ");

    var choice = Console.ReadLine();
    if (choice is null) continue;
    if (choice.Equals("x", StringComparison.OrdinalIgnoreCase)) break;

    switch (choice)
    {
        case "1":
            Console.Write("Docent (id;naam): ");
            var d = Console.ReadLine()?.Split(';', StringSplitOptions.TrimEntries) ?? Array.Empty<string>();
            if (d.Length >= 2) docenten.Add(d);
            break;

        case "2":
            Console.Write("Student (id;naam): ");
            var s = Console.ReadLine()?.Split(';', StringSplitOptions.TrimEntries) ?? Array.Empty<string>();
            if (s.Length >= 2) studenten.Add(s);
            break;

        case "3":
            Console.Write("Score (studentId;vak;score): ");
            var sc = Console.ReadLine()?.Split(';', StringSplitOptions.TrimEntries) ?? Array.Empty<string>();
            if (sc.Length >= 3) scores.Add(sc);
            break;

        case "4":
            foreach (var doc in docenten)
                Console.WriteLine($"{doc[0]} - {doc[1]}");
            break;

        case "5":
            foreach (var st in studenten)
            {
                string sid = st[0];
                int passed = 0;
                foreach (var row in scores)
                {
                    if (row[0] == sid && int.TryParse(row[2], out var val) && val >= 10) passed++;
                }
                Console.WriteLine($"{st[1]}: {passed} geslaagde vakken");
            }
            break;

        default:
            Console.WriteLine("Onbekende keuze.");
            break;
    }

    Console.WriteLine();
}
