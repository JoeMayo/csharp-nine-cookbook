namespace Section_05_01
{
    public class InventoryItem
    {
        [Column("Part #")]
        public string PartNumber { get; set; }

        [Column("Name")]
        public string Description { get; set; }

        [Column("Amount")]
        public int Count { get; set; }

        [Column("Price")]
        public decimal ItemPrice { get; set; }

        [Column("Total")]
        public decimal CalculateTotal()
        {
            return ItemPrice * Count;
        }
    }
}
