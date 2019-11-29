namespace RefMan.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CredentialsBase
    {
        [Required(ErrorMessage = "A username is required.")]
        [MaxLength(32, ErrorMessage = "Usernames cannot be longer than 32 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}