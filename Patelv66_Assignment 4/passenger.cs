// Name: Vraj Pareshkumar Patel
// ID: 3154641


public class Passenger
{
    public string FirstName { get; }
    public string LastName { get; }
    public SeatLabel PreferredSeat { get; }

    public Passenger(string firstName, string lastName, SeatLabel preferredSeat)
    {
        FirstName = firstName;
        LastName = lastName;
        PreferredSeat = preferredSeat;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public string GetInitials()
    {
        return $"{FirstName[0]}{LastName[0]}";
    }
}
