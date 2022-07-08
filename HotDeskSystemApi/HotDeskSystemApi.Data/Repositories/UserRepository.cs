using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotDeskSystemApi.Data.Entities;

namespace HotDeskSystemApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public UserRepository(IConfiguration configuration)
        {
            _context = new AppDbContext(configuration);
        }
        public User? GetUser(string username, string password, string role)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username && u.Role == role && u.Password == password);
        }
    }
}
