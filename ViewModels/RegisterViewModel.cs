using System.ComponentModel.DataAnnotations;

namespace AdrianWoronaProject91511.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Musisz podać adres e-mail")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        public  string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Musisz podać hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Musisz powtórzyć hasło")]
        [Compare("Password", ErrorMessage ="Hasła muszą być takie same")]
        public string CheckPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
