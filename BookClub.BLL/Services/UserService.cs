using BookClub.BLL.DTO;
using BookClub.BLL.Infrastructure;
using BookClub.BLL.Interfaces;
using BookClub.DAL.EF;
using BookClub.DAL.Entities;
using BookClub.DAL.Repositories;

namespace BookClub.BLL.Services
{
    internal class UserService : IUserService
    {
        private readonly BookClubContext _context;
        private readonly UserRepository _userRepository;

        public UserService(BookClubContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
        }

        public ApplicationUser Authorization(UserDTO userDTO)
        {
            ApplicationUser applicationUser = null;

           var user = _userRepository.FindByLogin(userDTO.Login);
            if (user != null)
                applicationUser = new ApplicationUser() { Id = user.Id, Login = user.Login };

           return applicationUser;
        }

        public OperationDetails Registration(UserDTO userDTO)
        {
            var user = _userRepository.FindByLogin(userDTO.Login);

            if (user == null)
            {
                User newUser = new User() { Login = userDTO.Login, Name = userDTO.Name };

                _userRepository.Create(newUser);
                _context.SaveChanges();
                return new OperationDetails(true, "Регистрация успешно пройдена");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует");
            }
        }

        public ApplicationUser AuthorizationAndRegistration(UserDTO userDTO)
        {
            ApplicationUser user = Authorization(userDTO);
            if (user == null)
            {
                Registration(userDTO);
                user = Authorization(userDTO);
            }
                
            return user;
        }
    }
}
