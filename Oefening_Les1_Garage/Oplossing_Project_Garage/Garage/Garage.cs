namespace Garage;
public class Garage
{
    private int capacity;
    private int occupancy=0;

    public Garage(int capacity) { }

    public bool IsFull()
    {
        return true;
    }

    public bool IsEmpty()
    {
        return true;
    }

    public void Enter(Vehicle v) { }

    public int RemaingCapacity()
    {
        return -1;
    }
}



