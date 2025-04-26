using Microsoft.AspNetCore.Mvc;
using Orders.Dal;
using SaleServer.DAL;
using SaleServer.Migrations;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.BL
{
    public class giftsBL : Igifts
    {
        private readonly IgiftsDal _giftsDAL;

        public giftsBL(IgiftsDal giftsDAL)
        {
            this._giftsDAL = giftsDAL??  throw new ArgumentNullException(nameof(giftsDAL));
        }


        public async Task<List<Gifts>> GetGifts()
        {
            return await _giftsDAL.GetAsync();
        }

        public async Task DeletGift(int giftId)
        {

            _giftsDAL.DeletGift(giftId);

        }
        public async Task AddGift(Gifts g)
        {
            _giftsDAL.AddGift(g);

        }

        public async Task UpdateGift(Gifts g)
        {
            _giftsDAL.UpdateGift(g);

        }
        public async Task<List<Gifts>> FindName(string name)
        {
           return await _giftsDAL.FindName(name);
        }
        public async Task<List<Gifts>> Findcategory(string category)
        {
            return await _giftsDAL.Findcategory(category);
        }
            
        public async Task<List<Gifts>> FindByDonorName(string donorName)
        {
            return await _giftsDAL.FindByDonorName(donorName);
        }
        public async Task<List<int>> GetAllGiftIdsFromOrders()
        {
            return await _giftsDAL.GetAllGiftIdsFromOrders();
        }
    }
}
