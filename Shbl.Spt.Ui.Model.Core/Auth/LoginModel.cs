using System.ComponentModel.DataAnnotations;

namespace Shbl.Spt.Ui.Model.Core.Auth;

public class LoginModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}