namespace JwtWebApiAuthorization.Controllers {

    using Token;
    using Models;

    using System.Web.Http;

    [RoutePrefix("tokens")]
    public class TokenController : ApiController {
        
        [HttpGet, Route("{role:int}")]
        public CustomResponse Get(Roles role) {

            var authorizationTokenWithRole = new AccessToken { Role = role }.ToTokenString();
            return new CustomResponse(authorizationTokenWithRole);
        }
    }
}
