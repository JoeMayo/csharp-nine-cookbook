using System;
using System.Collections.Generic;

namespace Section_08_04
{
    class Program
    {
        const int RoomNotAvailable = -1;

        static void Main()
        {
            Console.Write(
                "Choose (1) Bronze, (2) Silver, or (3) Gold: ");
            string choice = Console.ReadLine();

            Enum.TryParse(choice, out ScheduleType scheduleType);

            int roomNumber = AssignRoom(scheduleType);

            if (roomNumber == RoomNotAvailable)
                Console.WriteLine("Room not available.");
            else
                Console.WriteLine($"The room number is {roomNumber}.");
        }

        static int AssignRoom(ScheduleType scheduleType)
        {
            foreach (var room in GetRooms())
            {
                ScheduleType roomType = room switch
                {
                    { BedSize: "King", RoomType: "Suite" } => ScheduleType.Gold,
                    { BedSize: "King", RoomType: "Regular" } => ScheduleType.Silver,
                    { BedSize: "Queen", RoomType: "Regular" } => ScheduleType.Bronze,
                    _ => ScheduleType.Bronze
                };

                if (roomType == scheduleType)
                    return room.Number;
            }

            return RoomNotAvailable;
        }

        static List<Room> GetRooms()
        {
            return new List<Room>
            {
                new Room
                {
                    Number = 333,
                    BedSize = "King",
                    RoomType = "Suite"
                },
                new Room
                {
                    Number = 222,
                    BedSize = "King",
                    RoomType = "Regular"
                },
                new Room
                {
                    Number = 111,
                    BedSize = "Queen",
                    RoomType = "Regular"
                },
            };
        }
    }
}
