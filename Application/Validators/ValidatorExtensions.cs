using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T,string> Password<T>(this IRuleBuilder<T,string> ruleBuilder){
            var rule = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Password must be minimum 6 characters.")
                .Matches("[A-Z]").WithMessage("Password must have at least one upper case letter.")
                .Matches("[a-z]").WithMessage("Password must have at least one lower case letter.")
                .Matches("[0-9]").WithMessage("Password must have at least one number.")
                .Matches("[^A-Za-z0-9]").WithMessage("Password must have at least one special character.");

            return rule;
        }
    }
}