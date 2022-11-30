using BookClub.DAL.EF;
using BookClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DAL.Repositories
{
    public class UserRepository
    {
        private readonly BookClubContext _context;

        public UserRepository(BookClubContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
           await _context.Users.AddAsync(user);
        }

        public async Task<User?> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> FindByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
