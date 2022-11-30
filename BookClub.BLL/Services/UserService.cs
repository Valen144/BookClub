using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;
using BookClub.BLL.Interfaces;
using BookClub.DAL.EF;
using BookClub.DAL.Entities;
using BookClub.DAL.Repositories;

namespace BookClub.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly BookClubContext _context;
        private readonly UserRepository _userRepository;

        public UserService(BookClubContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
        }

        public async Task<ApplicationUser?> Authorization(UserDTO userDTO)
        {
            ApplicationUser? applicationUser = null;

           var user = await _userRepository.FindByLogin(userDTO.Login);
            if (user != null)
                applicationUser = new ApplicationUser() { Id = user.Id, Login = user.Login };

           return applicationUser;
        }

        public async Task<OperationDetails> Registration(UserDTO userDTO)
        {
            var user = await _userRepository.FindByLogin(userDTO.Login);

            if (user == null)
            {
                User newUser = new() { Login = userDTO.Login, Name = userDTO.Name };

                await _userRepository.Create(newUser);
                await _context.SaveChangesAsync();

                return new OperationDetails(true, "Регистрация успешно пройдена");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует");
            }
        }

        public async Task<ApplicationUser?> AuthorizationAndRegistration(UserDTO userDTO)
        {
            ApplicationUser? user = await Authorization(userDTO);
            if (user == null)
            {
                await Registration(userDTO);
                user = await Authorization(userDTO);
            }
                
            return user;
        }
    }
}
