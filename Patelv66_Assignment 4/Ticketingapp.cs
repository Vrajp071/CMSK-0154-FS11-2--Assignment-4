// Name: Vraj Pareshkumar Patel
// ID: 3154641

using System;
using System.Collections.Generic;

public class TicketingApp
{
    private List<Row> rows = new List<Row>();
    private bool isRunning = true;

    public TicketingApp()
    {
        InitializePlane();
    }

    private void InitializePlane()
    {
        for (int i = 1; i <= 12; i++)
        {
            rows.Add(new Row(i));
        }
    }

    public void Run()
    {
        while (isRunning)
        {
            DisplayMenu();
            int choice = GetChoice();
            ProcessChoice(choice);
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nPlease enter:");
        Console.WriteLine("No.1 to book a ticket.");
        Console.WriteLine("No.2 to see seating chart.");
        Console.WriteLine("No.3 to exit the application.");
    }

    private int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid input. Please enter a valid option:");
        }
        return choice;
    }

    private void ProcessChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                BookTicketLoop();
                break;
            case 2:
                DisplaySeatingChart();
                break;
            case 3:
                isRunning = false;
                Console.WriteLine("Exiting the application. Thank you!");
                break;
        }
    }

    private void BookTicketLoop()
    {
        bool continueBooking = true;

        do
        {
            BookTicket();

            Console.Write("\nDo you want to book another ticket? (yes/no): ");
            string answer = Console.ReadLine();
            continueBooking = answer.Equals("yes", StringComparison.OrdinalIgnoreCase);

        } while (continueBooking);
    }

    private void BookTicket()
    {
        Console.WriteLine("\nPlease enter the passenger's details:");
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter 1 for a Window seat, 2 for an Aisle seat, or press Enter for any seat:");
        SeatLabel preferredSeat = SeatLabel.A;
        string input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int choice))
        {
            if (choice == 2)
            {
                preferredSeat = SeatLabel.B;
            }
        }

        bool seatBooked = false;
        foreach (var row in rows)
        {
            foreach (var seat in row.Seats)
            {
                if (!seat.IsBooked && seat.Label == preferredSeat)
                {
                    seat.BookSeat(new Passenger(firstName, lastName, preferredSeat));
                    Console.WriteLine($"The seat located in row {seat.RowNumber} {seat} has been booked for {firstName} {lastName}.");
                    seatBooked = true;
                    break;
                }
            }
            if (seatBooked) break;
        }

        if (!seatBooked)
        {
            Console.WriteLine("Sorry, no suitable seat is available.");
        }
    }

    private void DisplaySeatingChart()
    {
        Console.WriteLine("\nCurrent Seating Chart:");
        foreach (var row in rows)
        {
            Console.WriteLine($"row {row.Seats.First().RowNumber}: {row}");
        }
    }
}
