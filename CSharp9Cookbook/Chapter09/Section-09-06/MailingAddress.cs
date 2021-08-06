namespace Section_09_06
{
    public record MailingAddress(
        string Street,
        string City,
        string State,
        string Zip,
        string Email,
        bool PreferEmail)
        : AddressBase(Street, City, State, Zip);
}
