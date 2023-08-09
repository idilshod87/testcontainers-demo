using NUnit.Framework;

using System.Net.Http.Json;

namespace TestContainers.Demo.IntegrationTests;

[TestFixture]
public class CustomersIntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task GetCustomers_ShouldReturnCustomerList()
    {
        // Arrange
        var client = TestApp.CreateClient();

        // Act
        var response = await client.GetAsync("/customers");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task CreateCustomers_ShouldReturnsNewCustomer()
    {
        // Arrange
        var client = TestApp.CreateClient();

        var newCustomer = new Customer
        {
            Id = 1,
            Name = "Paxlavon Maxmud",
            Address = new()
            {
                Country = "UZ",
                City = "Xorazm"
            }
        };

        // Act
        var response = await client.PostAsJsonAsync("/customers", newCustomer);

        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Customer>();
        Assert.AreEqual(result!.Address!.Country!, "UZ");
    }
}
