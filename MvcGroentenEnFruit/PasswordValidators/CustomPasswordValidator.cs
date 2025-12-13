using Microsoft.AspNetCore.Identity;

namespace MvcGroentenEnFruit.PasswordValidators
{
    public class CustomPasswordValidator : PasswordValidator<IdentityUser>
    {

        public override async Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string? password)
        {
            var result = await base.ValidateAsync(manager, user, password);
            if (result.Succeeded)
            {
                if (password!.Contains("123") || password.Contains("abc"))
                {
                    var error = new IdentityError()
                    {
                        Description = "Combinatie abc of 123 mag niet voorkomen in het wachtwoord!"
                    };
                    return IdentityResult.Failed(error);    
                }
            }
            return result;
        }
    }
}
