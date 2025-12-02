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
    public void IsFull_ShouldReturnFalse_WhenGarageIsEmpty()
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
    public void IsFull_ShouldReturnTrue_WhenGarageIsFull()
    {
        // Arrange
        const int capacity = 2;
        var garage = new Garage(capacity);
        Vehicle vehicle1 = new Vehicle();
        Vehicle vehicle2 = new Vehicle();

        // Act
        garage.Enter(vehicle1);
        garage.Enter(vehicle2);
        var result = garage.IsFull();

        // Assert
        Assert.That(result, Is.True);
    }


    [Test]
    public void Garage_CannotHaveNegativeCapacity_WhenCreated()
    {
        // Arrange
        const int negativeCapacity = -2;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new Garage(negativeCapacity));
    }

    [TestCase(3)]
    [TestCase(7)]
    [TestCase(8000)]
    public void Garage_ShouldHaveCapacity_WhenConstructed(int constructionCapacity)
    {
        // Arrange
        var garage = new Garage(constructionCapacity);

        // Act
        var result = garage.capacity;

        // Assert
        Assert.That(result, Is.EqualTo(constructionCapacity));
    }

    [Test]
    public void IsEmpty_ShouldReturnFalse_WhenAVehicleHasEntered()
    {
        // Arrange
        var garage = new Garage(5);
        var vehicle = new Vehicle();

        // Act
        garage.Enter(vehicle);
        var result = garage.IsEmpty();

        // Assert
        Assert.That(result, Is.False);
    }
}
