using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Section_05_03
{
    public class MarkdownGenerator<TData> : GeneratorBase<TData>
    {
        const string ColumnSeparator = " | ";

        protected override StringBuilder GetTitle()
        {
            return new StringBuilder("# Report\n\n");
        }

        protected override StringBuilder GetHeaders(
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

        protected override StringBuilder GetRows(
            List<TData> items,
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
    }
}
