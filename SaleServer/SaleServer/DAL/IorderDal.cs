using SaleServer.DTO;
using SaleServer.Models;

namespace SaleServer.DAL
{
    public interface IorderDal
    {
        Task AddToBasket(int userId, int giftId, int quantity);
        Task RemoveFromBasket(int userId, int giftId);
        Task<decimal> ProcessPaymentAndCreateOrder(int userId);
        Task<Gifts> SortByHigestPrice();
        Task<Gifts> MostParchased();
        Task<List<User>> GetGiftBayers(int giftId);
        Task<List<User>> GetBayersDetails();
       Task<List<Cart>> ShowMyCart1(int userId);
        Task RemoveQuantityFromBasket(int userId, int giftId, int quantity);
        public decimal SumForPaying(int userId);
        public Task<decimal> CalculateTotalOrdersAmount();
    }
}
