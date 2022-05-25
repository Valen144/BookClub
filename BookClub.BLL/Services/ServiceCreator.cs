using BookClub.BLL.Interfaces;
using BookClub.DAL.EF;

namespace BookClub.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IReadingRoomService CreateReadingRoomService()
        {
            return new ReadingRoomService(new BookClubContext());
        }

        public IUserService CreateUserService()
        {
            return new UserService(new BookClubContext());
        }
    }
}
