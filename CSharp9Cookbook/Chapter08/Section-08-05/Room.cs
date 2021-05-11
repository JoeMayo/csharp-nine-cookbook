using System;
namespace Section_08_05
{
    public class Room
    {
        public int Number { get; set; }
        public string RoomType { get; set; }
        public string BedSize { get; set; }

        public void Deconstruct(out string size, out string type)
        {
            size = BedSize;
            type = RoomType;
        }
    }
}
