#pragma warning disable CA1707 // Identifiers should not contain underscores
using System;
using System.Collections.Generic;
using Hw2.Exercise5.Models;
using Hw2.Exercise5.Services;
using Xunit;

namespace Hw2.Tests.Exercise5
{
    public record Request(
        string TransactionId,
        decimal Amount,
        string Currency,
        string SourceUserId,
        string DestUserId,
        string SourceBalance,
        string DestBalance,
        bool OverdraftAllowed,
        DateTimeOffset Timestamp,
        string Metadata) : ITransactionRequest;

    public class BillingServiceTests
    {
        public static IEnumerable<object[]> GetInvalidRequests()
        {
            var invalidRequests = new List<object[]>
            {
                new object[] { null },
                new object[] { new Request("trx", -1, "cur", "suid", "duid", "sb", "db", false, DateTimeOffset.Now, null) },
                new object[] { new Request(null, 1, "cur", "suid", "duid", "sb", "db", false, DateTimeOffset.Now, null) },
                new object[] { new Request("trx", 1, null, "suid", "duid", "sb", "db", false, DateTimeOffset.Now, null) },
                new object[] { new Request("trx", 1, "cur", null, "duid", "sb", "db", false, DateTimeOffset.Now, null) },
                new object[] { new Request("trx", 1, "cur", null, null, "sb", "db", false, DateTimeOffset.Now, null) },
                new object[] { new Request("trx", 1, "cur", null, null, null, "db", false, DateTimeOffset.Now, null) },
                new object[] { new Request("trx", 1, "cur", null, null, null, null, false, DateTimeOffset.Now, null) },
                new object[] { new Request(null, 0, null, null, null, null, null, false, default, null) },
                new object[] { new Request("trx", 1, "cur", "suid", "suid", "sb", "sb", false, DateTimeOffset.Now, null) }
            };
            return invalidRequests;
        }

        [Theory]
        [MemberData(nameof(GetInvalidRequests))]
        public void Process_InvalidRequest_ReturnsError(Request request)
        {
            var billing = new BillingService() as IBillingService;
            var response = billing.ProcessTransaction(request);
            Assert.NotNull(response);
            Assert.Equal(TransactionResult.InvalidRequest, response.Result);
        }

        [Fact]
        public void Process_ValidRequestsForSameUser_ReturnsResult()
        {
            var billing = new BillingService() as IBillingService;
            var requests = new[]
            {
                new Request("trx1", 10m, "USD", "user1", "user1", "deposit", "main",   true, DateTimeOffset.Now, null),
                new Request("trx2",  9m, "USD", "user1", "user1", "main", "purchases", false, DateTimeOffset.Now, null)
            };
            foreach (var request in requests)
            {
                var response = billing.ProcessTransaction(request);
                Assert.NotNull(response);
                Assert.Equal(TransactionResult.Success, response.Result);
            }
            var user = billing.GetUserBalances("user1");
            Assert.NotNull(user);
            Assert.NotNull(user.Balances);

            Assert.True(user.Balances.ContainsKey("USD"));
            Assert.True(user.Balances["USD"].ContainsKey("main"));
            Assert.True(user.Balances["USD"].ContainsKey("deposit"));
            Assert.True(user.Balances["USD"].ContainsKey("purchases"));

            Assert.Equal(1m, user.Balances["USD"]["main"]);
            Assert.Equal(-10m, user.Balances["USD"]["deposit"]);
            Assert.Equal(9m, user.Balances["USD"]["purchases"]);
        }

        [Fact]
        public void Process_ValidRequestsForDifferentUser_ReturnsResult()
        {
            var billing = new BillingService() as IBillingService;
            var requests = new[]
            {
                new Request("trx1", 10m, "USD", "user1", "user1", "deposit", "main",   true, DateTimeOffset.Now, null),
                new Request("trx2",  5m, "USD", "user1", "user1", "main", "purchases", false, DateTimeOffset.Now, null),
                new Request("trx3",  4m, "USD", "user1", "user2", "main", "main", false, DateTimeOffset.Now, null)
            };
            foreach (var request in requests)
            {
                var response = billing.ProcessTransaction(request);
                Assert.NotNull(response);
                Assert.Equal(TransactionResult.Success, response.Result);
            }
            var user1 = billing.GetUserBalances("user1");

            Assert.NotNull(user1);
            Assert.NotNull(user1.Balances);

            Assert.True(user1.Balances.ContainsKey("USD"));
            Assert.True(user1.Balances["USD"].ContainsKey("main"));
            Assert.True(user1.Balances["USD"].ContainsKey("deposit"));
            Assert.True(user1.Balances["USD"].ContainsKey("purchases"));

            Assert.Equal(1m, user1.Balances["USD"]["main"]);
            Assert.Equal(-10m, user1.Balances["USD"]["deposit"]);
            Assert.Equal(5m, user1.Balances["USD"]["purchases"]);

            var user2 = billing.GetUserBalances("user2");

            Assert.NotNull(user2);
            Assert.NotNull(user2.Balances);

            Assert.True(user2.Balances.ContainsKey("USD"));
            Assert.True(user2.Balances["USD"].ContainsKey("main"));

            Assert.Equal(4m, user2.Balances["USD"]["main"]);
        }

        [Fact]
        public void Process_OverLimitRequestsForSameUser_ReturnsInsufficientFunds()
        {
            var billing = new BillingService() as IBillingService;

            var user = billing.GetUserBalances("user1");
            if (user?.Balances is not null)
            {
                Assert.Empty(user.Balances);
            }

            var request1 = new Request("trx1", 10m, "USD", "user1", "user1", "deposit", "main", true, DateTimeOffset.Now, null);
            var request2 = new Request("trx2", 11m, "USD", "user1", "user1", "main", "purchases", false, DateTimeOffset.Now, null);

            var response = billing.ProcessTransaction(request1);
            Assert.NotNull(response);
            Assert.Equal(TransactionResult.Success, response.Result);

            response = billing.ProcessTransaction(request2);
            Assert.NotNull(response);
            Assert.Equal(TransactionResult.InsufficientFunds, response.Result);

            user = billing.GetUserBalances("user1");
            Assert.NotNull(user);
            Assert.NotNull(user.Balances);

            Assert.True(user.Balances.ContainsKey("USD"));
            Assert.True(user.Balances["USD"].ContainsKey("main"));
            Assert.True(user.Balances["USD"].ContainsKey("deposit"));

            Assert.Equal(10m, user.Balances["USD"]["main"]);
            Assert.Equal(-10m, user.Balances["USD"]["deposit"]);

            if (user.Balances["USD"].ContainsKey("purchases"))
            {
                Assert.Equal(0m, user.Balances["USD"]["purchases"]);
            }
        }
    }
}
#pragma warning restore CA1707 // Identifiers should not contain underscores
