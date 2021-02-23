using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Section_05_01
{
    public class Report
    {
        public string Generate(List<object> items)
        {
            _ = items ??
                throw new ArgumentNullException(
                    $"{items} is required");
            MemberInfo[] members =
                items.First().GetType().GetMembers();

            var report = new StringBuilder("# Report\n\n");

            report.Append(GetHeaders(members));
            //report.Append(GetRows(items));

            return report.ToString();
        }

        StringBuilder GetHeaders(MemberInfo[] members)
        {
            var columnNames = new List<string>();
            var underscores = new List<string>();

            foreach (var member in members)
            {
                var attribute =
                    member.GetCustomAttribute<ColumnAttribute>();

                if (attribute != null)
                {
                    string columnTitle = attribute.Name;
                    string dashes = "".PadLeft(columnTitle.Length, '-');

                    columnNames.Add(columnTitle);
                    underscores.Add(dashes);
                }
            }

            var header = new StringBuilder();

            header.Append(string.Join(" | ", columnNames));
            header.Append("\n");

            header.Append(string.Join(" | ", underscores));
            header.Append("\n");

            return header;
        }

        bool GetRows(List<object> items)
        {
            throw new NotImplementedException();
        }
    }
}
