using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Section_05_03
{
    public abstract class GeneratorBase<TData>
    {
        public string Generate(List<TData> items)
        {
            StringBuilder report = GetTitle();

            Dictionary<string, ColumnDetail> columnDetails =
                GetColumnDetails(items);
            report.Append(GetHeaders(columnDetails));
            report.Append(GetRows(items, columnDetails));

            return report.ToString();
        }

        protected abstract StringBuilder GetTitle();

        protected abstract StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details);

        protected abstract StringBuilder GetRows(
            List<TData> items,
            Dictionary<string, ColumnDetail> details);


        Dictionary<string, ColumnDetail> GetColumnDetails(
            List<TData> items)
        {
            TData itemInstance = items.First();
            Type itemType = itemInstance.GetType();
            PropertyInfo[] itemProperties = itemType.GetProperties();

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

        protected List<string> GetColumns(
            IEnumerable<ColumnDetail> details,
            TData item)
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

        (object, Type) GetReflectedResult(TData item, PropertyInfo property)
        {
            object result = property.GetValue(item);
            Type type = property.PropertyType;

            return (result, type);
        }
    }
}
