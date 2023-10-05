using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace API.Controllers
{
    public class GoogleAuth : BaseController
    {
        [Route ("singin-google")]
        public IActionResult GoogleLogIn(){
            var properties = new AuthenticationProperties {
                RedirectUri = Url.Action ("GoogleReponse")
            };
            return Challenge (properties, GoogleDefaults.AuthenticationScheme);
        }
        [HttpPost]
        [Route("GoogleReponse")]
        public async Task<IActionResult> GoogleResponse(){
            var result = await HttpContext.AuthenticateAsync (CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault()
            .Claims.Select(claim => new {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            return Ok(claims);
        }
    }
}