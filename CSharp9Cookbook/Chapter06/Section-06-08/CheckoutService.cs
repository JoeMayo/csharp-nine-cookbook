using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Section_06_08
{
    public class CheckoutService
    {
        class AllTasksResult
        {
            public bool IsValidAddress { get; set; }
            public bool IsValidCredit { get; set; }
            public bool HasShoppingCart { get; set; }
        }

        public async Task<string> StartBigONAsync()
        {
            (_, bool addressResult) = await ValidateAddressAsync();
            (_, bool creditResult) = await ValidateCreditAsync();
            (_, bool cartResult) = await GetShoppingCartAsync();

            await FinalizeCheckoutAsync(
                new AllTasksResult
                {
                    IsValidAddress = addressResult,
                    IsValidCredit = creditResult,
                    HasShoppingCart = cartResult
                });

            return "Checkout Complete";
        }

        public async Task<string> StartBigO1Async()
        {
            var checkoutTasks =
                new List<Task<(string, bool)>>
                {
                    ValidateAddressAsync(),
                    ValidateCreditAsync(),
                    GetShoppingCartAsync()
                };

            Task<(string method, bool result)[]> allTasks =
                Task.WhenAll(checkoutTasks);

            if (allTasks.IsCompletedSuccessfully)
            {
                AllTasksResult allResult = GetResults(allTasks);

                await FinalizeCheckoutAsync(allResult);

                return "Checkout Complete";
            }
            else
            {
                throw allTasks.Exception;
            }
        }

        public async Task<string> StartBigONSquaredAsync()
        {
            var checkoutTasks =
                new List<Task<(string, bool)>>
                {
                    ValidateAddressAsync(),
                    ValidateCreditAsync(),
                    GetShoppingCartAsync()
                };

            var allResult = new AllTasksResult();

            while (checkoutTasks.Any())
            {
                Task<(string, bool)> task = await Task.WhenAny(checkoutTasks);
                checkoutTasks.Remove(task);

                GetResult(task, allResult);
            }

            await FinalizeCheckoutAsync(allResult);

            return "Checkout Complete";
        }

        void GetResult(
            Task<(string method, bool result)> task,
            AllTasksResult allResult)
        {
            (string method, bool result) = task.Result;

            switch (task.Result.method)
            {
                case nameof(ValidateAddressAsync):
                    allResult.IsValidAddress = result;
                    break;
                case nameof(ValidateCreditAsync):
                    allResult.IsValidCredit = result;
                    break;
                case nameof(GetShoppingCartAsync):
                    allResult.HasShoppingCart = result;
                    break;
            }
        }

        AllTasksResult GetResults(
            Task<(string method, bool result)[]> allTasks)
        {
            var allResult = new AllTasksResult();

            foreach (var (method, result) in allTasks.Result)
                switch (method)
                {
                    case nameof(ValidateAddressAsync):
                        allResult.IsValidAddress = result;
                        break;
                    case nameof(ValidateCreditAsync):
                        allResult.IsValidCredit = result;
                        break;
                    case nameof(GetShoppingCartAsync):
                        allResult.HasShoppingCart = result;
                        break;
                }

            return allResult;
        }

        async Task<(string method, bool result)> ValidateAddressAsync()
        {
            //throw new ArgumentException("Testing!");

            return await Task.FromResult(
                (nameof(ValidateAddressAsync), true));
        }

        async Task<(string method, bool result)> ValidateCreditAsync()
        {
            var checkoutTasks =
                new List<Task<(string, bool)>>
                {
                    CheckInternalCreditAsync(),
                    CheckAgency1CreditAsync(),
                    CheckAgency2CreditAsync()
                };

            Task<(string, bool)> task = await Task.WhenAny(checkoutTasks);

            (_, bool result) = task.Result;

            return await Task.FromResult(
                (nameof(ValidateCreditAsync), result));
        }

        async Task<(string, bool)> CheckInternalCreditAsync()
        {
            return await Task.FromResult(
                (nameof(CheckInternalCreditAsync), true));
        }

        async Task<(string, bool)> CheckAgency1CreditAsync()
        {
            return await Task.FromResult(
                (nameof(CheckAgency1CreditAsync), true));
        }

        async Task<(string, bool)> CheckAgency2CreditAsync()
        {
            return await Task.FromResult(
                (nameof(CheckAgency2CreditAsync), true));
        }

        async Task<(string method, bool result)> GetShoppingCartAsync()
        {
            return await Task.FromResult(
                (nameof(GetShoppingCartAsync), true));
        }

        async Task<bool> FinalizeCheckoutAsync(AllTasksResult allResult)
        {
            Console.WriteLine(
                $"{nameof(AllTasksResult.IsValidAddress)}: " +
                $"{allResult.IsValidAddress}");
            Console.WriteLine(
                $"{nameof(AllTasksResult.IsValidCredit)}: " +
                $"{allResult.IsValidCredit}");
            Console.WriteLine(
                $"{nameof(AllTasksResult.HasShoppingCart)}: " +
                $"{allResult.HasShoppingCart}");

            bool success = true;
            return await Task.FromResult(success);
        }
    }
}
