using BookClub.DAL.EF;
using BookClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DAL.Repositories
{
    public class BookHistoryRepository
    {
        private readonly BookClubContext _context;

        public BookHistoryRepository(BookClubContext context)
        {
            _context = context;
        }

        public async Task Create(BookHistory bookHistory)
        {
            await _context.AddAsync(bookHistory);
        }

        public async Task Delete(int id)
        {
            BookHistory? item = await _context.BookHistories.FindAsync(id);
            if (item != null)
                _context.BookHistories.Remove(item);
        }

        public async Task<bool> IsAnyBookUser(int idBook, int idUser)
        {
            return await GetBookHistories()
                .AnyAsync(x => x.User.Id == idUser && x.Book.Id == idBook);
        }

        public async Task<IEnumerable<BookHistory>> GetBookHistories(int id)
        {
            return await GetBookHistories()
                .Where(x => x.User.Id == id).ToListAsync();
        }

        public IQueryable<BookHistory> GetBookHistories()
        {
            return _context.BookHistories
                .Include(x => x.User)
                .Include(x => x.Book);
        }
    }
}
