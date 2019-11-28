namespace RefMan.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Registration : CredentialsBase
    {
        [Required(ErrorMessage = "You must repeat your password.")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [DisplayName("Repeat Password")]
        public string RepeatPassword { get; set; }
    }
}