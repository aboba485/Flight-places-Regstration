using System;

namespace FlightRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sectors = { 6, 7, 9, 10, 11, 12, 13 };
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                DisplayAvailableSeats(sectors);

                Console.WriteLine("\nFlight registration menu:");
                Console.WriteLine("1 - Register a seat");
                Console.WriteLine("2 - Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterSeat(sectors);
                        break;
                    case "2":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void DisplayAvailableSeats(int[] sectors)
        {
            Console.WriteLine("Available Seats:");
            for (int i = 0; i < sectors.Length; i++)
            {
                Console.WriteLine($"Sector {i + 1}: {sectors[i]} seats available");
            }
        }

        static void RegisterSeat(int[] sectors)
        {
            Console.Write("Enter the sector number: ");
            int sectorNumber;
            if (!int.TryParse(Console.ReadLine(), out sectorNumber) || sectorNumber < 1 || sectorNumber > sectors.Length)
            {
                Console.WriteLine("Invalid sector number.");
                return;
            }

            Console.Write("Enter the number of seats to book: ");
            int seatsToBook;
            if (!int.TryParse(Console.ReadLine(), out seatsToBook) || seatsToBook < 1 || seatsToBook > sectors[sectorNumber - 1])
            {
                Console.WriteLine($"Invalid number of seats. There are only {sectors[sectorNumber - 1]} seats available in sector {sectorNumber}.");
                return;
            }

            sectors[sectorNumber - 1] -= seatsToBook;
            Console.WriteLine($"Successfully booked {seatsToBook} seats in sector {sectorNumber}.");
        }
    }
}
