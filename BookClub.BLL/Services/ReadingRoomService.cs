using AutoMapper;
using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;
using BookClub.BLL.Interfaces;
using BookClub.DAL.EF;
using BookClub.DAL.Entities;
using BookClub.DAL.Repositories;

namespace BookClub.BLL.Services
{
    public class ReadingRoomService : IReadingRoomService
    {
        private readonly BookClubContext _context;
        private readonly BookRepository _bookRepository;
        private readonly BookHistoryRepository _bookHistoryRepository;
        private readonly UserRepository _userRepository;

        public ReadingRoomService(BookClubContext context)
        {
            _context = context;
            _bookRepository = new BookRepository(context);
            _bookHistoryRepository = new BookHistoryRepository(context);
            _userRepository = new UserRepository(context);
        }

        public async Task<OperationDetails> AddBook(BookHistoryDTO bookHistoryDTO)
        {
            var bookhistory = await _bookHistoryRepository.IsAnyBookUser(bookHistoryDTO.BookId, bookHistoryDTO.UserId);
            if (bookhistory)
                return new OperationDetails(false, "Книга уже была добавлена");

            var book = await _bookRepository.Get(bookHistoryDTO.BookId);  
            if (book == null)
                return new OperationDetails(false, $"Книга не найдена");

            var user = await _userRepository.Get(bookHistoryDTO.UserId);
            if (user == null)
                return new OperationDetails(false, $"Пользователь не найден");

            await _bookHistoryRepository.Create(new BookHistory() { Book = book, User = user, ReadDate = bookHistoryDTO.ReadDate });    
            await _context.SaveChangesAsync();

            return new OperationDetails(true, "Книга добавлена");
        }

        public async Task RemoveBook(int id)
        { 
            await _bookHistoryRepository.Delete(id);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(await _bookRepository.GetAll());
        }

        public async Task<IEnumerable<BookHistoryDTO>> GetUserBookHistory(int userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookHistory, BookHistoryDTO>()
            .ForMember(x => x.BookName, x => x.MapFrom(c => c.Book.Name))
            .ForMember(x => x.BookId, x => x.MapFrom(c => c.Book.Id))
            .ForMember(x => x.UserId, x => x.MapFrom(c => c.User.Id))).CreateMapper();

            return mapper.Map<IEnumerable<BookHistory>, List<BookHistoryDTO>>(await _bookHistoryRepository.GetBookHistories(userId));
        }
    }
}
