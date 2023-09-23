using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoobookSystemsLLC.Entities.Concrete;

namespace ZoobookSystemsLLC.Entities.Dtos
{
    public class EmployeeAddDto : IValidatableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new EmployeeAddDtoValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class EmployeeAddDtoValidator : AbstractValidator<EmployeeAddDto>
    {
        public EmployeeAddDtoValidator()
        {
            RuleFor(o => o.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(o => o.LastName).NotEmpty().WithMessage("LastName cannot be empty");
        }
    }
}
