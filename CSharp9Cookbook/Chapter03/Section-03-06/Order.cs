using System;
using System.Text;

namespace Section_03_06
{
    class Order
    {
        public int ID { get; set; }

        public string CustomerName { get; set; }

        public DateTime Created { get; set; }

        public decimal Amount { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(nameof(Order));
            stringBuilder.Append(" {\n");

            if (PrintMembers(stringBuilder))
                stringBuilder.Append(" ");

            stringBuilder.Append("\n}");

            return stringBuilder.ToString();
        }

		protected virtual bool PrintMembers(StringBuilder builder)
		{
			builder.Append("  " + nameof(ID));
			builder.Append(" = ");
			builder.Append(ID);
			builder.Append(", \n");
			builder.Append("  " + nameof(CustomerName));
			builder.Append(" = ");
			builder.Append(CustomerName);
			builder.Append(", \n");
			builder.Append("  " + nameof(Created));
			builder.Append(" = ");
			builder.Append(Created.ToString("d"));
			builder.Append(", \n");
			builder.Append("  " + nameof(Amount));
			builder.Append(" = ");
			builder.Append(Amount);

			return true;
		}
	}
}
