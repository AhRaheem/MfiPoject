
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.User
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IUserService _UserService;

        public UserCreateDtoValidator(IFileService FileService, IUserService UserService) 
        {
            _FileService = FileService;
            _UserService = UserService;

            RuleFor(x => x.UserName).NotNull().WithMessage("Name Required").MustAsync(UserNameExits).WithMessage("Name Exits");
            RuleFor(x => x.Email).NotNull().WithMessage("Name Required").MustAsync(UserEmailExits).WithMessage("Name Exits");
        }

        public async Task<bool> UserNameExits(string TitleAr, CancellationToken arg2)
        {
            var Galry = await _UserService.GetByName(TitleAr);
            return Galry is null;
        }

        public async Task<bool> UserEmailExits(string Title, CancellationToken arg2)
        {
            var Galry = await _UserService.GetByEmail(Title);
            return Galry is null;
        }
    }
}
