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

        public void Create(BookHistory bookHistory)
        {
            _context.Add(bookHistory);
        }

        public virtual void Delete(int id)
        {
            BookHistory item = _context.BookHistories.Find(id);
            if (item != null)
                _context.BookHistories.Remove(item);
        }

        public bool IsAnyBookUser(int idBook, int idUser)
        {
            return GetBookHistories().Any(x => x.User.Id == idUser && x.Book.Id == idBook);
        }

        public IEnumerable<BookHistory> GetBookHistories(int id)
        {
            return GetBookHistories().Where(x => x.User.Id == id).ToList();
        }

        public IEnumerable<BookHistory> GetBookHistories()
        {
            return  _context.BookHistories
                .Include(x => x.User)
                .Include(x => x.Book).ToList();
        }
    }
}
