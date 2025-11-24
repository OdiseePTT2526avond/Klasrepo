namespace OdiseeAdmin3.Models;

public class Score
{
    public string StudentId { get; }
    public string Vak { get; }
    public int Waarde { get; }

    public Score(string studentId, string vak, int waarde)
    {
        StudentId = studentId;
        Vak = vak;
        Waarde = waarde;
    }

    public override string ToString() => $"{StudentId} {Vak} {Waarde}/20";
}
