namespace Garage;
public class Garage
{
    public int capacity; // 200
    public int occupancy; // 0 -> 10 -> 200

    public Garage(int capacity) {
        if (capacity < 0)
        {
            throw new ArgumentException("Een Garage kan geen negatieve capaciteit hebben");
        }

        this.capacity = capacity;
        this.occupancy = 0;
    }

    public bool IsFull()
    {
        return occupancy == capacity;
    }

    public bool IsEmpty()
    {
        return occupancy == 0;
    }

    public void Enter(Vehicle v) {
        occupancy += 1;
    }
}



