
namespace StringCalculator.tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        /// Req 1
        public void Calculate_GivenEmptyString_Result0()
        {
            //ARRANGE - Given
            string input = "";
            //ACT - When
            int result = Calculator.Calculate(input);

            //ASSERT - Then/Result
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
