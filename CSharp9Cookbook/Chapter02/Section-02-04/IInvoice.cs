namespace Section_02_04
{
    public interface IInvoice
    {
        bool IsApproved();

        void PopulateLineItems();

        void CalculateBalance();

        void SetDueDate();
    }
}
