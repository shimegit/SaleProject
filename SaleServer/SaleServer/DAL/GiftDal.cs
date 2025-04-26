using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleServer.DAL;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    internal class giftDal : IgiftsDal
    {
        private readonly SaleContext _saleContext;

        public giftDal(SaleContext saleContext)
        {
            this._saleContext=saleContext ?? throw new ArgumentNullException(nameof(saleContext));
        }



        public async Task<List<Gifts>> GetAsync()
        {
            return await _saleContext.Gifts.ToListAsync();
        }

        public async Task DeletGift(int giftId)
        {

            var gift = _saleContext.Gifts.Find(giftId);

            if (gift != null)
            {
                _saleContext.Gifts.Remove(gift);
                _saleContext.SaveChanges();
            }

        }

        public async Task AddGift(Gifts g)
        {
            var existingGift = _saleContext.Gifts.FirstOrDefault(gift => gift.name == g.name);
            if (existingGift != null)
            {
                var errorResponse = new BadRequestObjectResult("Gift with the same name already exists");
                throw new Exception(errorResponse.Value.ToString());
            }

            _saleContext.Gifts.Add(g);
            _saleContext.SaveChanges();
        }

        public async Task UpdateGift(Gifts g)
        {
            _saleContext.Gifts.Update(g);
            _saleContext.SaveChanges();
        }
        public async Task<List<Gifts>> FindName(string name)
        {
            List<Gifts> filteredGifts = await _saleContext.Gifts
                                                            .Where(g => g.name == name)
                                                            .ToListAsync();
            return filteredGifts;
        }
        public async Task<List<Gifts>> Findcategory(string category)
        {
            List<Gifts> filteredGifts = await _saleContext.Gifts
                                                            .Where(g => g.category == category)
                                                            .ToListAsync();
            return filteredGifts;
        }
        public async Task<List<Gifts>> FindByDonorName(string donorName)
        {
            var filteredGifts = await _saleContext.Gifts
                                                    .Where(d => d.donor.name == donorName)
                                                     .Select(g => g)
                                                     .ToListAsync();

            return filteredGifts;
        }
        public async Task<List<int>> GetAllGiftIdsFromOrders()
        {
            var giftIds = await _saleContext.Order
                .SelectMany(o => o.orderItems.Select(oi => oi.Id))
                .Distinct()
                .ToListAsync();

            return giftIds;
        }
    }

}
