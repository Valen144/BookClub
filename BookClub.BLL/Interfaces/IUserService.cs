using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;

namespace BookClub.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser?> AuthorizationAndRegistration(UserDTO userDTO);
        Task<ApplicationUser?> Authorization(UserDTO userDTO);
        Task<OperationDetails> Registration(UserDTO userDTO);
    }
}
