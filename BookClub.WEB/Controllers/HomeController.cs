using BookClub.BLL.DTO;
using BookClub.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookClub.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadingRoomService _readingRoomService;

        public HomeController(IReadingRoomService readingRoomService)
        {
            _readingRoomService = readingRoomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return View(await GetBooks());
        }

        [HttpPost]
        public async Task<IActionResult> AddBookToUser(int id)
        {
          var operation = await _readingRoomService.AddBook(new BookHistoryDTO()
          {
                BookId = id,
                UserId = GetIdUser(),
                ReadDate = DateTime.Now    
          });

            if (!operation.Succedeed)
                ModelState.AddModelError("", operation.Message);

            return RedirectToAction("GetAllBooks");
        }

        [HttpGet]
        public async Task<IActionResult> UserReadBook()
        {
            return View(await GetBooksHistory());
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReadBook(int idBookHistory)
        {
            await _readingRoomService.RemoveBook(idBookHistory);
            return RedirectToAction("UserReadBook");
        }

        private async Task<IEnumerable<BookDTO>> GetBooks()
        { 
            return await _readingRoomService.GetBooks();
        }

        private async Task<IEnumerable<BookHistoryDTO>> GetBooksHistory()
        {
            return await _readingRoomService.GetUserBookHistory(GetIdUser());
        }

        private int GetIdUser()
        {
           return Convert.ToInt32(HttpContext.Request.Cookies["UserId"]);
        }
    }
}