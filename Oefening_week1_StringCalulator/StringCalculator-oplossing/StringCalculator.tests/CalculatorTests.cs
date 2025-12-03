using StringCalculator;
namespace StringCalculator.tests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        /// Req 1
        public void Calculate_GivenEmptyString_Returns0()
        {
            //ARRANGE - Given
            string input = "";
            //ACT - When
            int result = Calculator.Calculate(input);

            //ASSERT - Then/Returns
            Assert.That(result, Is.EqualTo(0));
        }

        // Requirement 2
        [Test]
        public void Calculate_GivenSingleNumber_ReturnsThatNumber()
        {
            // Arrange
            string input = "42";

            // Act
            int result = Calculator.Calculate(input);

            // Assert
            Assert.That(result, Is.EqualTo(42));
        }

        // Requirement 3
        [Test]
        public void Calulcate_GivenTwoNumbersSeparatedByComma_ReturnsSum()
        {
            // Arrange
            string input = "11,32";

            // Act
            int result = Calculator.Calculate(input);

            // Assert
            Assert.That(result, Is.EqualTo(43));
        }

        // Requirement 4
        [Test]
        public void Calculate_GivenTwoNumbersSeparatedByNewLine_ReturnsSum()
        {
            string input = "5\n7";
            int result = Calculator.Calculate(input);
            Assert.That(result, Is.EqualTo(12));
        }

        // Requirement 5
        [Test]
        public void Calculate_GivenMoreNumbers_ReturnsSum()
        {
            // Arrange
            string input = "1\n2,3\n4";

            // Act
            int result = Calculator.Calculate(input);

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        // Requirement 6
        [TestCase("1,2,-1")]
        [TestCase("-55")]
        public void Calculate_GivenNegativeNumber_ShouldThrowArgumentException(string input)
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Calculator.Calculate(input));
        }

        // Requirement 6
        [TestCase("0", 0)] // edge case
        public void Calculate_GivenNonNegativeNumber_ShouldNotThrowArgumentException(string input, int result)
        {
            // The should not throw check is implicit, because if something IS thrown, the test will fail anyway
            // Act + Assert
            int res=Calculator.Calculate(input);
            Assert.That(result, Is.EqualTo(res));
        }

        // Requirement 7
        [Test]
        public void Calculate_GivenNumbersGreaterThan1000_ShouldIgnoreThem()
        {
            // Arrange  - edge cases 1000 and 1001
            string input = "2,1000,0,1001,10005";

            // Act
            int result = Calculator.Calculate(input);

            // Assert
            Assert.That(result, Is.EqualTo(1002));
        }



    }
}