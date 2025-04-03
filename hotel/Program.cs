using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

class Room
{
    public decimal RoomNumber { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Room(int roomNumber)
    {
        RoomNumber = roomNumber;
    }
}
class Reservation
{
    public Room Room { get; set; }
    public Customer Customer { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    public Reservation(Room room, Customer customer, DateTime checkIn, DateTime checkOut)
    {
        Room = room;
        Customer = customer;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Room.IsAvailable = false;
    }
}
class Customer
{
    public string Name { get; set; }
    public int CustomerId { get; set; }

    public Customer(string name, int customerId)
    {
        Name = name;
        CustomerId = customerId;
    }
}
class Hotel
{
    private List<Room> Rooms = new List<Room>();
    private List<Reservation> Reservations = new List<Reservation>();

    public Hotel(int roomCouunt)
    {
        for (int i = 1; i <= roomCouunt; i++)
        {
            Rooms.Add(new Room(i));
        }
    }
    public void ShowAvailableRooms()
    {
        var availableRooms = Rooms.Where(r => r.IsAvailable);

        Console.WriteLine("Dostępne pokoje");
        foreach (var room in availableRooms)
        {
            Console.WriteLine(room.RoomNumber);
        }
    }
    public void MakeReservation(int roomNumber, Customer customer, DateTime checkIn, DateTime checkOut)
    {
        var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);
        if (room != null)
        {
            var reservation = new Reservation(room, customer, checkIn, checkOut);
            Reservations.Add(reservation);
            Console.WriteLine($"Rezerwacja potwierdzona dla {customer.Name} w pokoju {roomNumber}.");
        }
        else
        {
            Console.WriteLine("Pokój nie jest dostępny");
        }
    }
    public void CancelReservation(int roomNumber)
    {
        var reservation = Reservations.FirstOrDefault(r => r.Room.RoomNumber == roomNumber);
        if (reservation != null)
        {
            reservation.Room.IsAvailable = true;
            Reservations.Remove(reservation);
            Console.WriteLine($"Rezerwacja dla pokoju {roomNumber} została anulowana");
        }
        else
        {
            Console.WriteLine("Nie znaleziono rezerwacji dla tego pokoju");
        }
    }

}

class Program
{
    static void Main()
    {
        Hotel hotel = new Hotel(5);
        Customer customer1 = new Customer("Jan Kowalski", 1);

        hotel.ShowAvailableRooms();
        hotel.MakeReservation(2, customer1, DateTime.Now, DateTime.Now.AddDays(2));
        hotel.ShowAvailableRooms();
        hotel.CancelReservation(2);
        hotel.ShowAvailableRooms();

        while (true)
        {
            Console.WriteLine("1. Pokaż dostępne pokoje");
            Console.WriteLine("2. Zarezerwuj pokój");
            Console.WriteLine("3. Anuluj rezerwację");
            int choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    hotel.ShowAvailableRooms();
                    break;
                case 2:
                    Console.WriteLine("Podaj numer pokoju: ");
                    int roomNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj imię i nazwisko: ");
                    string name = Console.ReadLine();
                    Customer newCustomer = new Customer(name, new Random().Next(1000));
                    hotel.MakeReservation(roomNumber, newCustomer, DateTime.Now, DateTime.Now.AddDays(2));
                    break;
                case 3:
                    Console.WriteLine("Podaj numer pokoju do anulowania rezerwacji: ");

            }
        }
    }
}