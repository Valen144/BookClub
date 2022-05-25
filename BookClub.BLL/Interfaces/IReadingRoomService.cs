using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;

namespace BookClub.BLL.Interfaces
{
    public interface IReadingRoomService
    {
        OperationDetails AddBook(BookHistoryDTO bookHistoryDTO);
        void RemoveBook(int id);
        IEnumerable<BookDTO> GetBooks();
        IEnumerable<BookHistoryDTO> GetBookHistories(int userId);
    }
}
