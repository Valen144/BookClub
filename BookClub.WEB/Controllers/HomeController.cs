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
        public IActionResult Index()
        {
            return View(GetBooks());
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
          var operation = _readingRoomService.AddBook(new BookHistoryDTO()
          {
                BookId = id,
                UserId = GetIdUser(),
                ReadDate = DateTime.Now    
          });

            if (!operation.Succedeed)
                ModelState.AddModelError("", operation.Message);
            return View(GetBooks());
        }

        [HttpGet]
        public IActionResult MyReadBook()
        {
            return View(GetBooksHistory());
        }

        [HttpPost]
        public IActionResult MyReadBook(int idBookHistory)
        {
            _readingRoomService.RemoveBook(idBookHistory);
            return RedirectToAction("MyReadBook");
        }

        private IEnumerable<BookDTO> GetBooks()
        { 
            return _readingRoomService.GetBooks();
        }

        private IEnumerable<BookHistoryDTO> GetBooksHistory()
        {
            return _readingRoomService.GetUserBookHistory(GetIdUser());
        }

        private int GetIdUser()
        {
           return Convert.ToInt32(HttpContext.Request.Cookies["UserId"]);
        }
    }
}