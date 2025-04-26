using SaleServer.Models;

namespace SaleServer.BL
{
    public interface IuserBL
    {
        public Task<User> AddUser(User user);
        public Task<User> Authenticate(User userLogin);

        public string GenerateUser(User user);
        
    }
}

