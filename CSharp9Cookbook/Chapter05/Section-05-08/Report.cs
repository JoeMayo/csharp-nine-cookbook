using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Section_05_08
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
            object itemInstance = items.First();
            Type itemType = itemInstance.GetType();
            PropertyInfo[] itemProperties = itemType.GetProperties();
            var membersFrom = itemType.IsAssignableFrom(typeof(DynamicObject));
            var membersTo = itemType.IsAssignableTo(typeof(DynamicObject));

            return
                (from prop in itemProperties
                 let attribute = prop.GetCustomAttribute<ColumnAttribute>()
                 where attribute != null
                 select new ColumnDetail
                 {
                     Name = prop.Name,
                     Attribute = attribute,
                     PropertyInfo = prop
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
            var rows = new StringBuilder();

            foreach (var item in items)
            {
                List<string> columns =
                    GetColumns(details.Values, item);

                rows.AppendJoin(ColumnSeparator, columns);

                rows.Append("\n");
            }

            return rows;
        }

        List<string> GetColumns(
            IEnumerable<ColumnDetail> details,
            object item)
        {
            var columns = new List<string>();

            foreach (var detail in details)
            {
                PropertyInfo member = detail.PropertyInfo;
                string format =
                    string.IsNullOrWhiteSpace(
                        detail.Attribute.Format) ?
                        "{0}" :
                        detail.Attribute.Format;

                (object result, Type columnType) =
                    GetReflectedResult(item, member);

                switch (columnType.Name)
                {
                    case "DateTime":
                        columns.Add(
                            string.Format(format, (DateTime)result));
                        break;
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
            object item, PropertyInfo property)
        {
            object result = property.GetValue(item);
            Type type = property.PropertyType;

            return (result, type);
        }
    }
}
