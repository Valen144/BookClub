using System.ComponentModel.DataAnnotations;

namespace BookClub.WEB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Логин")]
        public string Login { get; set; }

    }
}