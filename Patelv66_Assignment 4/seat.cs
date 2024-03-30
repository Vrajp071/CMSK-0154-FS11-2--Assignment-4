// Name: Vraj Pareshkumar Patel
// ID: 3154641

public enum SeatLabel
{
    A,
    B,
    C,
    D
}

public class Seat
{
    public bool IsBooked { get; set; }
    public Passenger Passenger { get; set; }
    public SeatLabel Label { get; }
    public int RowNumber { get; }

    public Seat(int rowNumber, SeatLabel label)
    {
        RowNumber = rowNumber;
        Label = label;
        IsBooked = false;
        Passenger = null;
    }

    public void BookSeat(Passenger passenger)
    {
        IsBooked = true;
        Passenger = passenger;
    }

    public override string ToString()
    {
        return $"{RowNumber}{Label}";
    }
}
