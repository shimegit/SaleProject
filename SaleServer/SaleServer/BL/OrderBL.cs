using Orders.Dal;
using SaleServer.DAL;
using SaleServer.DTO;
using SaleServer.Models;

namespace SaleServer.BL
{
    public class OrderBl : IorderBL
    {
        private readonly IorderDal _orderDAL;

        public OrderBl(IorderDal orderDAL)
        {
            this._orderDAL = orderDAL ?? throw new ArgumentNullException(nameof(orderDAL));
        }
        public async Task AddToBasket(int userId, int giftId, int quantity)
        {
            _orderDAL.AddToBasket(userId, giftId, quantity);
        }

        public async Task RemoveFromBasket(int userId, int giftId)
        {
            _orderDAL.RemoveFromBasket(userId, giftId);
        }
        public async Task<decimal> ProcessPaymentAndCreateOrder(int userId)
        {
            return await _orderDAL.ProcessPaymentAndCreateOrder(userId);
        }
        public async Task<Gifts> SortByHigestPrice()
        {
            return await _orderDAL.SortByHigestPrice();
        }
        public async Task<Gifts> MostParchased()
        {
            return await _orderDAL.MostParchased();
        }
        public async Task<List<User>> GetGiftBayers(int giftId)
        {
            return await _orderDAL.GetGiftBayers(giftId);
        }
        public async Task<List<User>> GetBayersDetails()
        {
            return await _orderDAL.GetBayersDetails();

        }
        public async Task<List<Cart>> ShowMyCart1(int userId)
        {
            return await _orderDAL.ShowMyCart1(userId);

        }
        public async Task RemoveQuantityFromBasket(int userId, int giftId, int quantity)
        {
            _orderDAL.RemoveQuantityFromBasket(userId, giftId, quantity);
        }
        public decimal SumForPaying(int userId)
        {
            return _orderDAL.SumForPaying(userId);
        }
        public async Task<decimal> CalculateTotalOrdersAmount()
        {
            return await _orderDAL.CalculateTotalOrdersAmount();
        }
    }
}


