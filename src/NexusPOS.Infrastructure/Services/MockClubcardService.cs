using NexusPOS.Application.Interfaces;
using System.Threading.Tasks;

namespace NexusPOS.Infrastructure.Services
{
    public class MockClubcardService : IClubcardService
    {
        public async Task<Customer?> GetCustomerAsync(string identifier)
        {
            // Simulate network delay
            await Task.Delay(500);

            if (string.IsNullOrWhiteSpace(identifier)) 
                return null;

            // Mock Data
            if (identifier == "1234")
                return new Customer("1234", "John Doe", 1500);
            
            if (identifier == "9999")
                return new Customer("9999", "Jane Smith", 42);

            // Default mock for any other valid input
            return new Customer(identifier, "Guest Shopper", 0);
        }
    }
}
