using Microsoft.EntityFrameworkCore;
using SaleServer.DAL;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    internal class donorDal : IdonorDal
    {
        private readonly SaleContext _saleContext;

        public donorDal(SaleContext saleContext)
        {
            this._saleContext=saleContext ?? throw new ArgumentNullException(nameof(saleContext));
        }



        public async Task<List<Donor>> GetAsync()
        {
            return await _saleContext.Donor.ToListAsync();
        }

        public async Task DeletDonor(int DonorId)
        {

            var donor = _saleContext.Donor.Find(DonorId);

            if (donor != null)
            {
                _saleContext.Donor.Remove(donor);
                _saleContext.SaveChanges();
            }

        }

        public async Task AddDonor(Donor g)
        {
            _saleContext.Donor.Add(g);
            _saleContext.SaveChanges();

        }

        public async Task UpdateDonor(Donor g)
        {
            _saleContext.Donor.Update(g);
            _saleContext.SaveChanges();
        }


        public async Task<List<Donor>> FindByName(string name)
        {
            List<Donor> filteredDonor = await _saleContext.Donor
                                                            .Where(g => g.name == name)
                                                            .ToListAsync();
            return filteredDonor;
        }
        public async Task<List<Donor>> FindByMail(string mail)
        {
            List<Donor> filteredGifts = await _saleContext.Donor
                                                            .Where(g => g.email == mail)
                                                            .ToListAsync();
            return filteredGifts;
        }
        public async Task<List<Donor>> FindByGift(string gift)

        {
            var filteredDonor = await _saleContext.Gifts
                                                      .Where(g => g.name == gift)
                                                      .Select(d => d.donor)
                                                      .ToListAsync();
            return filteredDonor;
        }
    }
}