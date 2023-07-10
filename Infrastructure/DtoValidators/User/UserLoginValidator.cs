
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.User
{
    public class UserLoginValidator : AbstractValidator<LoginViewModel>
    {
        public UserLoginValidator() 
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Name Required");
            RuleFor(x => x.Password).NotNull().WithMessage("Password Required");
        }
    }
}
