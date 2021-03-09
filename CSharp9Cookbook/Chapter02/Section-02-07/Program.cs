using System;

namespace Section_02_07
{
    class Program
    {
        static readonly DateTime LinuxEpoch =
            new DateTime(1970, 1, 1, 0, 0, 0, 0);
        static readonly DateTime WindowsEpoch =
            new DateTime(0001, 1, 1, 0, 0, 0, 0);
        static readonly double EpochMillisecondDifference = 
            new TimeSpan(
                LinuxEpoch.Ticks - WindowsEpoch.Ticks).TotalMilliseconds;

        static void Main()
        {
            Console.WriteLine(
                $"WindowsEpoch == DateTime.MinValue: " +
                $"{WindowsEpoch == DateTime.MinValue}");

            DateTime testDate = new DateTime(2021, 01, 01);

            Console.WriteLine($"testDate: {testDate}");

            string linuxTimestamp = ToLinuxTimestampFromDateTime(testDate);

            TimeSpan dotnetTimeSpan =
                TimeSpan.FromMilliseconds(long.Parse(linuxTimestamp));
            DateTime problemDate =
                new DateTime(dotnetTimeSpan.Ticks);

            Console.WriteLine(
                $"Accidentally based on .NET Epoch: {problemDate}");

            DateTime goodDate = ToDateTimeFromLinuxTimestamp(linuxTimestamp);

            Console.WriteLine(
                $"Properly based on Linux Epoch: {goodDate}");
        }

        public static string ToLinuxTimestampFromDateTime(DateTime date)
        {
            double dotnetMilliseconds = TimeSpan.FromTicks(date.Ticks).TotalMilliseconds;
            
            double linuxMilliseconds = dotnetMilliseconds - EpochMillisecondDifference;

            double timestamp = Math.Round(
                linuxMilliseconds, 0, MidpointRounding.AwayFromZero);

            return timestamp.ToString();
        }

        public static DateTime ToDateTimeFromLinuxTimestamp(string timestamp)
        {
            ulong.TryParse(timestamp, out ulong epochMilliseconds);
            return LinuxEpoch + TimeSpan.FromMilliseconds(epochMilliseconds);
        }
    }
}
