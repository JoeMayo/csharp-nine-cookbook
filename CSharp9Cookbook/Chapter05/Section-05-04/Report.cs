using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Section_05_04
{
    public class Report
    {
        const string ColumnSeparator = " | ";

        public string Generate(List<object> items)
        {
            var report = new StringBuilder("# Report\n\n");

            Dictionary<string, ColumnDetail> columnDetails =
                GetColumnDetails(items);
            report.Append(GetHeaders(columnDetails));
            report.Append(GetRows(items, columnDetails));

            return report.ToString();
        }

        Dictionary<string, ColumnDetail> GetColumnDetails(
            List<object> items)
        {
            return
                (from member in
                    items.First().GetType().GetMembers()
                 let attribute =
                    member.GetCustomAttribute<ColumnAttribute>()
                 where attribute != null
                 select new ColumnDetail
                 {
                     Name = member.Name,
                     Attribute = attribute,
                     MemberInfo = member
                 })
                .ToDictionary(
                    key => key.Name,
                    val => val);
        }

        StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
        {
            var header = new StringBuilder();

            header.AppendJoin(
                ColumnSeparator,
                from detail in details.Values
                select detail.Attribute.Name);

            header.Append("\n");

            header.AppendJoin(
                ColumnSeparator,
                from detail in details.Values
                let length = detail.Attribute.Name.Length
                select "".PadLeft(length, '-'));

            header.Append("\n");

            return header;
        }

        StringBuilder GetRows(
            List<object> items,
            Dictionary<string, ColumnDetail> details)
        {
            StringBuilder rows = new StringBuilder();
            Type itemType = items.First().GetType();

            foreach (var item in items)
            {
                List<string> columns =
                    GetColumns(details.Values, itemType, item);

                rows.AppendJoin(ColumnSeparator, columns);

                rows.Append("\n");
            }

            return rows;
        }

        List<string> GetColumns(
            IEnumerable<ColumnDetail> details,
            Type itemType,
            object item)
        {
            var columns = new List<string>();

            foreach (var detail in details)
            {
                MemberInfo member = detail.MemberInfo;
                string format =
                    string.IsNullOrWhiteSpace(
                        detail.Attribute.Format) ?
                        "{0}" :
                        detail.Attribute.Format;

                (object result, Type columnType) =
                    GetReflectedResult(itemType, item, member);

                switch (columnType.Name)
                {
                    case "Decimal":
                        columns.Add(
                            string.Format(format, (decimal)result));
                        break;
                    case "Int32":
                        columns.Add(
                            string.Format(format, (int)result));
                        break;
                    case "String":
                        columns.Add(
                            string.Format(format, (string)result));
                        break;
                    default:
                        break;
                }
            }

            return columns;
        }

        (object, Type) GetReflectedResult(
            Type itemType, object item, MemberInfo member)
        {
            object result;
            Type type;

            switch (member.MemberType)
            {
                case MemberTypes.Method:
                    MethodInfo method =
                        itemType.GetMethod(member.Name);
                    result = method.Invoke(item, null);
                    type = method.ReturnType;
                    break;
                case MemberTypes.Property:
                    PropertyInfo property =
                        itemType.GetProperty(member.Name);
                    result = property.GetValue(item);
                    type = property.PropertyType;
                    break;
                default:
                    throw new ArgumentException(
                        "Expected property or method.");
            }

            return (result, type);
        }
    }
}
