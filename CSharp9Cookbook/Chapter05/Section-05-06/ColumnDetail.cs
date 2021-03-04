using System.Reflection;

namespace Section_05_06
{
    public class ColumnDetail
    {
        public string Name { get; set; }

        public ColumnAttribute Attribute { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }
}
