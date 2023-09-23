using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Entities.Dtos
{
    public class UserLoginDto : IValidatableObject
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserLoginDtoValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(o => o.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(o => o.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}
