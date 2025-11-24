using System.Collections.Generic;
using System.Linq;
using OdiseeAdmin3.Models;

namespace OdiseeAdmin3.Domain;

public class School
{
    private readonly List<Docent> _docenten = new();
    private readonly List<Student> _studenten = new();
    private readonly List<Score> _scores = new();

    // Mutaties
    public void AddDocent(Docent d) => _docenten.Add(d);
    public void AddStudent(Student s) => _studenten.Add(s);
    public void AddScore(Score sc) => _scores.Add(sc);

    // Queries (read-only views)
    public IEnumerable<Docent> GetDocenten() => _docenten;
    public IEnumerable<Student> GetStudenten() => _studenten;
    public IEnumerable<Score> GetScores() => _scores;

    // Domeinlogica: tel # geslaagde vakken per student (>= 10)
    public IEnumerable<(Student student, int geslaagd)> GetStudentenMetAantalGeslaagdeVakken(int grens = 10)
        => _studenten.Select(st =>
        {
            var count = _scores.Count(sc => sc.StudentId == st.Id && sc.Waarde >= grens);
            return (st, count);
        });
}
