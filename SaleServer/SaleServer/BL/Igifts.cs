using Microsoft.AspNetCore.Mvc;
using Orders.Dal;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.BL
{
    public interface Igifts
    {
        Task<List<Gifts>> GetGifts();
        Task DeletGift(int giftId);
        Task AddGift(Gifts gift);
        Task UpdateGift(Gifts gift);
        Task<List<Gifts>> FindName(string name);
        Task<List<Gifts>> Findcategory(string category);
        Task<List<Gifts>> FindByDonorName(string donorName);
        Task<List<int>> GetAllGiftIdsFromOrders();
    }
}
