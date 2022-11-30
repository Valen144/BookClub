using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;

namespace BookClub.BLL.Interfaces
{
    public interface IReadingRoomService
    {
        Task<OperationDetails> AddBook(BookHistoryDTO bookHistoryDTO);
        Task RemoveBook(int id);
        Task<IEnumerable<BookDTO>> GetBooks();
        Task<IEnumerable<BookHistoryDTO>> GetUserBookHistory(int userId);
    }
}
