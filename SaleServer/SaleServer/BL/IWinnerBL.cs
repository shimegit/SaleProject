using Microsoft.AspNetCore.Mvc;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    public interface IWinnerBl
    {
        public Task<bool> PerformLottery();
        public Task<List<Winner>> GetWinners();
        public Task<List<Dictionary<string, List<string>>>> GenerateWinnerReport();

    }
}