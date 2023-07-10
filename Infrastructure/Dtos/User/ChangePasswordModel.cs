using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.User
{
    public class ChangePasswordModel
    {
        public string? UserId { get; set; }
        
        [DataType(DataType.Password)]
        [TranslateDisplay("Current password")]
        public string? OldPassword { get; set; }

        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [TranslateDisplay("New password")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [TranslateDisplay("Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
