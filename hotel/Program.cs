using System;
using System.Collections.Generic;
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

    public Hotel (int roomCouunt)
    {
        for (int i = 1; i<= roomCouunt; i++)
        {
            Rooms.Add(new Room(i));
        }
    }
    public void ShowAvailableRooms()
    {
        var availableRooms = Rooms.Where(r => r.IsAviailable);
    }
}

class Program
{
    static void Main()
    {
        Hotel hotel = new Hotel(5);
        Customer customer1 = new Customer("Jan Kowalski", 1);

        hotel.ShowAvailablerRooms();
        hotel.MakeReservation(2, customer1, DateTime.Now, DateTime.Now.AddDays(2));
        hotel.ShowAvailableRooms();
        hotel.CancelReservation(2);
        hotel.ShowAvailableRooms();
    }
}