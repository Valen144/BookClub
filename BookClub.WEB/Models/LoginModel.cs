using System.ComponentModel.DataAnnotations;

namespace BookClub.WEB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Укажите логин")]
        public string Login { get; set; }
    }
}