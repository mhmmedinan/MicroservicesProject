using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator:IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existsUser = await _userManager.FindByEmailAsync(context.UserName);

            if (existsUser==null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string>{"Email veya şifreniz yanlış"});

                context.Result.CustomResponse = errors;
                return;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(existsUser, context.Password);
            if (passwordCheck == false)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });

                context.Result.CustomResponse = errors;
                return;
            }

            context.Result =
                new GrantValidationResult(existsUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
