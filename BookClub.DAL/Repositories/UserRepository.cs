using BookClub.DAL.EF;
using BookClub.DAL.Entities;

namespace BookClub.DAL.Repositories
{
    public class UserRepository
    {
        private readonly BookClubContext _context;

        public UserRepository(BookClubContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public User FindByLogin(string login)
        {
            return _context.Users.FirstOrDefault(x => x.Login == login);
        }
    }
}
