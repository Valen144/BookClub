using BookClub.DAL.EF;
using BookClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DAL.Repositories
{
    public class BookRepository
    {
        private readonly BookClubContext _context;

        public BookRepository(BookClubContext context)
        {
            _context = context;
        }

        public async Task<Book?> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
