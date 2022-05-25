using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;

namespace BookClub.BLL.Interfaces
{
    public interface IUserService
    {
        ApplicationUser AuthorizationAndRegistration(UserDTO userDTO);
        ApplicationUser Authorization(UserDTO userDTO);
        OperationDetails Registration(UserDTO userDTO);
    }
}
