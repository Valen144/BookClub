using BookClub.DAL.EF;
using BookClub.DAL.Entities;

namespace BookClub.DAL.Repositories
{
    public class BookRepository
    {
        private readonly BookClubContext _context;

        public BookRepository(BookClubContext context)
        {
            _context = context;
        }

        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }
    }
}
