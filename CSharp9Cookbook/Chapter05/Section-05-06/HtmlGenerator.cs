using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Section_05_06
{
    public class HtmlGenerator<TData> : GeneratorBase<TData>
    {
        protected override StringBuilder GetTitle()
        {
            return new StringBuilder("<h1>Report</h1>\n");
        }

        protected override StringBuilder GetHeaders(
            Dictionary<string, ColumnDetail> details)
        {
            var header = new StringBuilder("<tr>\n");

            header.AppendJoin(
                "\n",
                from detail in details.Values
                let columnName = detail.Attribute.Name
                select $"  <th>{columnName}</th>");

            header.Append("\n</tr>\n");

            return header;
        }

        protected override StringBuilder GetRows(
            List<TData> items,
            Dictionary<string, ColumnDetail> details)
        {
            StringBuilder rows = new StringBuilder();
            Type itemType = items.First().GetType();

            foreach (var item in items)
            {
                rows.Append("<tr>\n");

                List<string> columns =
                    GetColumns(details.Values, item);

                rows.AppendJoin(
                    "\n",
                    from columnValue in columns
                    select $"  <td>{columnValue}</td>");

                rows.Append("\n</tr>\n");
            }

            return rows;
        }
    }
}
