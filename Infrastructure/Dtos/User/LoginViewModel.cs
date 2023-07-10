using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.User
{
    public class LoginViewModel
    {
        [TranslateDisplay()]
        //[EmailAddress]
        public string? UserName { get; set; }

        [TranslateDisplay()]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [TranslateDisplay("Remember me")]
        public bool RememberMe { get; set; }
    }
}
