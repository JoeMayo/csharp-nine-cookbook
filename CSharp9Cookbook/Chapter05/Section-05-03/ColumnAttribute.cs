using System;

namespace Section_05_03
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Method,
        AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Format { get; set; }
    }
}
