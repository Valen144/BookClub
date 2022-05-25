namespace BookClub.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService();
        IReadingRoomService CreateReadingRoomService();
    }
}
