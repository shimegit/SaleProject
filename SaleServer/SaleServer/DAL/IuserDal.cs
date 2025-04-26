using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    public interface IuserDal
    { 
        Task<User> AddUserDal(User user);
        public Task<User> AuthenticateDal(User userLogin);

    }
}
