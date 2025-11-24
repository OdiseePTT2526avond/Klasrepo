using System.Collections.Generic;

namespace OdiseeAdmin2.Models;

public class Student
{
    public static List<Student> Studenten { get; } = new();

    private string voornaam;
    private string achternaam;

    public Student(string voornaam, string achternaam)
    {
        this.voornaam = voornaam;
        this.achternaam = achternaam;
        Studenten.Add(this);
    }

    public override string ToString() => $"{voornaam} {achternaam}";
}
