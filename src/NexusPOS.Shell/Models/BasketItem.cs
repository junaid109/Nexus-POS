namespace NexusPOS.Shell.Models
{
    public record BasketItem(string Sku, string Name, decimal Price, int Quantity = 1);
}
