using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verschilrijen;

using NUnit.Framework;

namespace Verschilrijen.tests
{
    public class RijboomTests
    {
        [Test] // Req11
        public void GivenBoomMet1Rij_Diepte_Returns1()
        {
            //Assert Een boom met 1 rij
            Rijboom b = new(new Rij(1, 2, 3));
            // Act
            int res = b.Diepte();
            //Assert diepte is 1
            Assert.That(res, Is.EqualTo(1));
        }

        [Test] //Req12
        public void GivenBoomMet1Rij_GetRij1_Returns1steRij()
        {
            //Assert Een boom met 1 rij
            Rij r = new(1, 2, 3);
            Rijboom b = new(r);
            // Act
            Rij res = b.GetRij(0);
            //Assert
            Assert.That(res.ToString(), Is.EqualTo(r.ToString()), "Niet dezelfde rij");
        }

        [Test] // Req13
        public void GivenBoom402_Bereken2Kinderen_ResultsIn242And022()
        {
            //Assert Een boom met 1 rij
            Rijboom b = new(new Rij(4, 0, 2));
            // Act
            b.BerekenKinderen(2);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(b.Diepte(), Is.EqualTo(3));
                Assert.That(b.GetRij(1).ToString(), Is.EqualTo("{2,4,2}"));
                Assert.That(b.GetRij(2).ToString(), Is.EqualTo("{0,2,2}"));
            });
        }

        [Test] // Req11
        public void GivenBoomMet3Rijen_Diepte_Returns3()
        {
            //Assert Een boom met 3 rijen
            Rijboom b = new(new Rij(1, 2, 3));
            b.BerekenKinderen(2);
            // Act
            int res = b.Diepte();
            //Assert diepte is 3
            Assert.That(res, Is.EqualTo(3));
            //of Assert.That(b.Diepte(), Is.EqualTo(3));
        }

        [Test] //Req 14
        public void GivenBoom4444_Bereken2Kinderen_ResultsInBoomDiepte2()
        {
            Rijboom b = new(new Rij(4, 4, 4, 4));
            b.BerekenKinderen(2);
            int res = b.Diepte();
            Assert.Multiple(() =>
            {
                Assert.That(res, Is.EqualTo(2));
                Assert.That(b.GetRij(1).ToString(), Is.EqualTo("{0,0,0,0}"));
            });
        }
    }
}
