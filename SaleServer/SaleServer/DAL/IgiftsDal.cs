using Microsoft.AspNetCore.Mvc;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    public interface IgiftsDal
    {
        Task<List<Gifts>> GetAsync();

        Task DeletGift(int giftId);

        Task AddGift(Gifts g);

        Task UpdateGift(Gifts gift);

         Task<List<Gifts>> FindName(string name);
        Task<List<Gifts>> Findcategory(string category);
        Task<List<Gifts>> FindByDonorName(string donorName);
        Task<List<int>> GetAllGiftIdsFromOrders();
    }
}
