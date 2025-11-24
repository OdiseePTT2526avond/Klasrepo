using OdiseeAdmin3.Domain;
using OdiseeAdmin3.Models;
using System;
using System.Reflection.Metadata;
using static System.Formats.Asn1.AsnWriter;

School school = new School();

while (true)
{
    PrintMenu();
    var keuze = Console.ReadLine();
    if (string.Equals(keuze, "x", StringComparison.OrdinalIgnoreCase)) break;

    switch (keuze)
    {
        case "1":
            Console.Write("Docent: id;voornaam;achternaam: ");
            var d = ReadParts(3);
            if (d != null)
            {
                school.AddDocent(new Docent(d[0], d[1], d[2]));
                Console.WriteLine("Docent toegevoegd.");
            }
            break;

        case "2":
            Console.Write("Student: id;voornaam;achternaam: ");
            var s = ReadParts(3);
            if (s != null)
            {
                school.AddStudent(new Student(s[0], s[1], s[2]));
                Console.WriteLine("Student toegevoegd.");
            }
            break;

        case "3":
            Console.Write("Score: studentId;vak;score: ");
            var sc = ReadParts(3);
            if (sc != null && int.TryParse(sc[2], out var waarde))
            {
                school.AddScore(new Score(sc[0], sc[1], waarde));
                Console.WriteLine("Score toegevoegd.");
            }
            break;

        case "4":
            Console.WriteLine("Docenten:");
            foreach (var doc in school.GetDocenten())
                Console.WriteLine($"- {doc.Id}  {doc.Voornaam} {doc.Achternaam}");
            break;

        case "5":
            Console.WriteLine("Studenten:");
            foreach (var st in school.GetStudenten())
                Console.WriteLine($"- {st.Id}  {st.Voornaam} {st.Achternaam}");
            break;

        case "6":
            Console.WriteLine("Scores:");
            foreach (var score in school.GetScores())
                Console.WriteLine($"- {score.StudentId}  {score.Vak}: {score.Waarde}/20");
            break;

        case "7":
            Console.WriteLine("Studenten en # geslaagde vakken (>=10):");
            foreach (var row in school.GetStudentenMetAantalGeslaagdeVakken())
                Console.WriteLine($"- {row.student.Voornaam} {row.student.Achternaam}: {row.geslaagd}");
            break;

        default:
            Console.WriteLine("Onbekende keuze.");
            break;
    }

    Console.WriteLine();
}

static void PrintMenu()
{
    Console.WriteLine("Welkom bij Odisee administratie (OdiseeAdmin3)");
    Console.WriteLine("1) Voeg docent toe (id;voornaam;achternaam)");
    Console.WriteLine("2) Voeg student toe (id;voornaam;achternaam)");
    Console.WriteLine("3) Voeg score toe (studentId;vak;score)");
    Console.WriteLine("4) Toon alle docenten");
    Console.WriteLine("5) Toon alle studenten");
    Console.WriteLine("6) Toon alle scores");
    Console.WriteLine("7) Toon studenten en aantal geslaagde vakken");
    Console.WriteLine("x) Sluit");
    Console.Write("> ");
}

static string[]? ReadParts(int expectedParts)
{
    var line = Console.ReadLine() ?? "";
    var parts = line.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length < expectedParts)
    {
        Console.WriteLine("✖ Onvolledige invoer.");
        return null;
    }
    return parts;
}
