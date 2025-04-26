using Microsoft.EntityFrameworkCore;
using SaleServer.BL;
using SaleServer.DAL;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    internal class UserDal : IuserDal
    {
        private readonly SaleContext _saleContext;

        public UserDal(SaleContext saleContext)
        {
            this._saleContext = saleContext ?? throw new ArgumentNullException(nameof(saleContext));
        }

        public async Task<User> AddUserDal(User user)
        {
            await _saleContext.User.AddAsync(user);
            await _saleContext.SaveChangesAsync();
            //var a = await _saleContext.User.ToListAsync();
            return user;
        }

        public async Task<User> AuthenticateDal(User userLogin)
        {
            var currentUser = _saleContext.User.FirstOrDefault(o => o.UserName.ToLower() ==
            userLogin.UserName.ToLower() && o.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
   
    }
}