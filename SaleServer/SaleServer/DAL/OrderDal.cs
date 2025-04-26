using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Dal;
using SaleServer.BL;
using SaleServer.DAL;
using SaleServer.DTO;
using SaleServer.Models;
using System;

namespace SaleServer.DAL
{
    public class OrderDal : IorderDal
    {
        private readonly SaleContext _saleContext;

        public OrderDal(SaleContext saleContext)
        {
            this._saleContext = saleContext ?? throw new ArgumentNullException(nameof(saleContext));
        }
        public async Task<decimal> ProcessPaymentAndCreateOrder(int userId)
        {
            var user = await _saleContext.User.Include(u => u.Carts).FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null && user.Carts != null && user.Carts.Any())
            {
                decimal totalAmount = 0;
                var orderItems = new List<Gifts>();

                foreach (var cartItem in user.Carts)
                {
                    var gift = await _saleContext.Gifts.FirstOrDefaultAsync(g => g.Id == cartItem.GiftId);
                    if (gift != null)
                    {
                        totalAmount += cartItem.Quantity * gift.ticketPrice;
                        orderItems.Add(gift);
                    }
                }

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    TotalAmount = totalAmount,
                    orderItems = orderItems
                };

                user.orders.Add(order);
                _saleContext.Cart.RemoveRange(user.Carts);
                await _saleContext.SaveChangesAsync();

                return totalAmount;
            }
            else
            {
                return 0;
            }
        }

        public async Task AddToBasket(int userId, int giftId, int quantity)
        {
            var user = _saleContext.User.Include(u => u.Carts).FirstOrDefault(u => u.UserId == userId);
            var cart = user.Carts.FirstOrDefault(c => c.GiftId == giftId);
            var gift = _saleContext.Gifts.Find(giftId);
            if (cart != null)
            {
                cart.Quantity = cart.Quantity * 1 + quantity * 1;
            }
            else
            {
                var cartItem = new Cart
                {
                    UserId = userId,
                    GiftId = giftId,
                    Quantity = quantity,
                    User = user,
                    Gift = gift
                };
                user.Carts.Add(cartItem);
            }

            _saleContext.SaveChanges();
        }

       
        public async Task<List<Cart>> ShowMyCart1(int userId)
        {
            var user = await _saleContext.User
                            .Include(u => u.Carts)
                              .ThenInclude(c => c.Gift)
                            .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                var gifts = user.Carts.Select(c => c).ToList();
                return gifts;
            }

            return null;
        }
        public async Task<Gifts> SortByHigestPrice()
        {

            var mostExpensiveGift = await _saleContext.Gifts
        .OrderByDescending(g => g.ticketPrice)
        .FirstOrDefaultAsync();

            return mostExpensiveGift;
        }
        public async Task RemoveQuantityFromBasket(int userId, int giftId, int quantity)
        {
           
            var user = _saleContext.User.Include(u => u.Carts).FirstOrDefault(u => u.UserId == userId);
            var cart = user.Carts.FirstOrDefault(c => c.GiftId == giftId);

            if (cart != null)
            {
                if (cart.Quantity >= quantity)
                {
                    cart.Quantity -= quantity;
                    _saleContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Error: Insufficient quantity in the basket.");
                }
            }
            else
            {
                throw new Exception("Error: Product not found in the basket.");
            }
        }

        public async Task RemoveFromBasket(int userId, int giftId)
        {
            var cartItem = _saleContext.Cart.FirstOrDefault(c => c.UserId == userId && c.GiftId == giftId);

            if (cartItem != null)
            {
                _saleContext.Cart.Remove(cartItem);
                _saleContext.SaveChanges();
            }

        }
        public async Task<Gifts> MostParchased()
        {
 
            var giftCounts = await _saleContext.Order
            .SelectMany(o => o.orderItems)
            .GroupBy(g => g.Id)
            .Select(g => new { Id = g.Key, Count = g.Count() })
            .ToListAsync();

            int mostPurchasedGiftId = giftCounts.OrderByDescending(g => g.Count)
                .Select(g => g.Id)
                .FirstOrDefault();

            var mostPurchasedGift = _saleContext.Gifts
                .FirstOrDefault(g => g.Id == mostPurchasedGiftId);

            return mostPurchasedGift;
        }
        public async Task<List<User>> GetGiftBayers(int giftId)
        {
            
            var buyers = await _saleContext.User
             .Where(u => u.orders
                 .Any(o => o.orderItems
                     .All(oi => oi.Id == giftId && oi.Id == giftId)))
             .ToListAsync();

            return buyers;


        }
        public async Task<List<User>> GetBayersDetails() 
        {
            var buyers = await _saleContext.User
             .Where(u => u.orders.Any())
             .Include(u => u.orders)
             .ToListAsync();

            return buyers;
        }
        public decimal SumForPaying(int userId)
        {
            var user = _saleContext.User.Include(u => u.Carts).FirstOrDefault(u => u.UserId == userId);

            if (user != null && user.Carts != null && user.Carts.Any())
            {
                decimal totalAmount = 0;


                foreach (var cartItem in user.Carts)
                {
                    var gift = _saleContext.Gifts.FirstOrDefault(g => g.Id == cartItem.GiftId);
                    if (gift != null)
                    {
                        totalAmount += cartItem.Quantity * gift.ticketPrice;

                    }
                }




                return totalAmount;
            }
            else
            {
                return 0;
            }
        }
        public async Task<decimal> CalculateTotalOrdersAmount()
        {
            var orders = await _saleContext.Order.ToListAsync();
            decimal totalAmount = orders.Sum(order => order.TotalAmount);
            return totalAmount;
        }
    }
}


    



