using System;
using System.Collections.Generic;
using System.Linq;

namespace Section_08_06
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
                    (_, "King", "Suite") => ScheduleType.Gold,
                    (_, "King", "Regular") => ScheduleType.Silver,
                    (_, "Queen", "Regular") => ScheduleType.Bronze,
                    _ => ScheduleType.Bronze
                };

                if (roomType == scheduleType)
                    return room.no;
            }

            return RoomNotAvailable;
        }

        static
            List<(int no, string size, string type)>
            GetRooms()
        {
            var rooms = GetHotel1Rooms().Union(GetHotel2Rooms());
            return
                (from room in rooms
                 select (
                    room.Number,
                    room.BedSize,
                    room.RoomType
                 ))
                .ToList();
        }

        static List<Room> GetHotel1Rooms()
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
                    Number = 111,
                    BedSize = "Queen",
                    RoomType = "Regular"
                },
            };
        }

        static List<Room> GetHotel2Rooms()
        {
            return new List<Room>
            {
                new Room
                {
                    Number = 222,
                    BedSize = "King",
                    RoomType = "Regular"
                },
            };
        }
    }
}
