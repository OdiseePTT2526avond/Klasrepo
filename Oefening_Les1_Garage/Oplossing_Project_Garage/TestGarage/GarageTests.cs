namespace TestGarage;

using Garage;

[TestFixture]
public class GarageTests
{
    private Vehicle vehicle1;
    private Vehicle vehicle2;

    [SetUp]
    public void SetUp()
    {
        vehicle1 = new Vehicle();
        vehicle2 = new Vehicle();
    }


    [Test]
    public void IsFull_ShouldReturnFalse_GivenGarageIsEmpty()
    {
        // Arrange
        int capacity = 10;
        var garage = new Garage(capacity);

        // Act
        var result = garage.IsFull();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsFull_ShouldReturnTrue_GivenGarageIsFull()
    {
        // Arrange
        const int capacity = 2;
        var garage = new Garage(capacity);
        Vehicle vehicle1 = new Vehicle();
        Vehicle vehicle2 = new Vehicle();
        garage.Enter(vehicle1);
        garage.Enter(vehicle2);

        // Act
        var result = garage.IsFull();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Garage_GivenNegativeCapacity_CannotBeCreated()
    {
        // Arrange
        const int negativeCapacity = -2;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new Garage(negativeCapacity));
    }

    [TestCase(2,0)]
    [TestCase(4,2)]
    [TestCase(10,8)]
    public void RemainingCapacity_Given2VehiclesEntered_ShouldReturn2Less(int constructionCapacity,int remainingCapacity)
    {
        // Arrange
        var garage = new Garage(constructionCapacity);
        garage.Enter(vehicle1);
        garage.Enter(vehicle2);

        // Act
        var result = garage.RemaingCapacity();

        // Assert
        Assert.That(result, Is.EqualTo(remainingCapacity));
    }
}
