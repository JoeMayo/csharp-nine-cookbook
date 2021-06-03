using System.Collections.Generic;

namespace Section_09_08
{
    public static class AddressExtensions
    {
        public static IEnumerator<string> GetEnumerator(
            this Address address)
        {
            yield return address.Street;
            yield return address.City;
            yield return address.State;
            yield return address.Zip;
            yield break;
        }
    }
}
