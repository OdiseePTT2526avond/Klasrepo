using NUnit.Framework;

namespace Verschilrijen.tests
{
    public class RijTests
    {
        //Geen test nodig voor req01

        [Test]    // Req02
        public void GivenNulRij_IsNul_ReturnsTrue()
        {
            // Arrange given a Rij that is a nulrij
            Rij rij = new Rij(0, 0, 0);
            //ACT isNul
            bool res = rij.IsNul();
            //Assert returns true
            Assert.That(res, Is.True, "Dit is wel een nulrij");
        }

        [Test]    // Req02
        public void GivenRij001_IsNul_ReturnsFalse()
        {
            // Arrange given a Rij that is not a nulrij
            Rij rij = new Rij(0, 0, 1);
            //ACT isNul
            bool res = rij.IsNul();
            //Assert returns False
            Assert.That(res, Is.False, "Dit is geen nulrij");
        }

        [Test]    // Req03
        public void GivenNulRij4_IsNul_ReturnsTrue()
        {
            // Arrange given a 4 element Rij that is a nulrij
            Rij rij = new Rij(0, 0, 0, 0);
            //ACT isNul
            bool res = rij.IsNul();
            //Assert returns true
            Assert.That(res, "Dit is geen nulrij");
        }

        [Test]    // Req02  Vermits we nu 4 getallen kunnen hebben, is nog een test voor req02 nodig
        public void GivenRij0001_IsNul_ReturnsFalse()
        {
            // Arrange given a Rij that is a nulrij
            Rij rij = new Rij(0, 0, 0, 1);
            //ACT isNul
            bool res = rij.IsNul();
            //Assert returns False
            Assert.That(!res, "Dit is geen nulrij");
        }

        [Test]   //Req04
        public void GivenVerschilRij3210_ToString_Returns3210()
        {
            // Arrange given a 4 element Rij
            Rij rij = new Rij(3, 2, 1, 0);
            //ACT toString
            string res = rij.ToString();
            //Assert returns true
            Assert.That(res, Is.EqualTo("{3,2,1,0}"));
        }

        [TestCase(new int[]{5, 3, 7}, "{2,2,4}")]  //  req05
        [TestCase(new int[] { 2, 7, 8, 1 }, "{1,5,1,7}")]
        public void GivenVerschilRij_BerekenKindRij_ReturnsKindrij(int[] input,string result)
        {
            //Arrange maak verschilrij
            Rij rij = new Rij(input);
            //Act Bereken kindrijen
            Rij kind = rij.BerekenKindRij();
            //Assert correcte kindrij?
            Assert.That(kind.ToString(), Is.EqualTo(result));
            //nog beter: implementeer bool Rij.Equals(Rij) -> Assert.IsTrue(kind.Equals(new Rij(5,3,7)));
        }
    }
}
