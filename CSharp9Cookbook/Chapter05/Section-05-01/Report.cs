using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Section_05_01
{
    public class Report
    {
        const string ColumnSeparator = " | ";

        public string Generate(List<object> items)
        {
            _ = items ??
                throw new ArgumentNullException(
                    $"{nameof(items)} is required");
            MemberInfo[] members =
                items.First().GetType().GetMembers();

            var report = new StringBuilder("# Report\n\n");

            report.Append(GetHeaders(members));

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

            header.AppendJoin(ColumnSeparator, columnNames);
            header.Append("\n");

            header.AppendJoin(ColumnSeparator, underscores);
            header.Append("\n");

            return header;
        }
    }
}
