using System.Threading.Tasks;

namespace NexusPOS.Application.Interfaces
{
    public record Customer(string Id, string Name, int PointsBalance);

    public interface IClubcardService
    {
        Task<Customer?> GetCustomerAsync(string identifier);
    }
}
