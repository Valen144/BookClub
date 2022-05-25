using BookClub.BLL.DTO;
using BookClub.BLL.Interfaces;
using BookClub.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View(GetBooksHistory(GetIdUser()));
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

        private IEnumerable<BookHistoryDTO> GetBooksHistory(int userId)
        {
            return _readingRoomService.GetBookHistories(userId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int GetIdUser()
        {
           return Convert.ToInt32(HttpContext.Request.Cookies["UserId"]);
        }
    }
}