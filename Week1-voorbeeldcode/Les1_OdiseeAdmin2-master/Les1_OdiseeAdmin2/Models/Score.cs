using System.Collections.Generic;

namespace OdiseeAdmin2.Models;

public class Score
{
    public static List<Score> Scores { get; } = new();

    private string studentNaam;
    private string vak;
    private int waarde;

    public Score(string studentNaam, string vak, int waarde)
    {
        this.studentNaam = studentNaam;
        this.vak = vak;
        this.waarde = waarde;
        Scores.Add(this);
    }

    public override string ToString() => $"{studentNaam} - {vak}: {waarde}/20";
}
