using System.Reflection;

namespace Section_05_04
{
    public class ColumnDetail
    {
        public string Name { get; set; }

        public ColumnAttribute Attribute { get; set; }

        public MemberInfo MemberInfo { get; set; }
    }
}
