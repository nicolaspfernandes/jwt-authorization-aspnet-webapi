namespace JwtWebApiAuthorization.Controllers {

    using Token;
    using Models;
    using Filters;

    using System.Web.Http;

    [RoutePrefix("requests")]
    public class RequestController : ApiController {

        [HttpGet, JwtApiAuthorization, Route("anonymous")]
        public CustomResponse RequestForAnonymousUsers() {
            return new CustomResponse {
                Data = "Request for anonymous users. Data is available for anyone, since this request is available for everyone."
            };
        }

        [HttpGet, JwtApiAuthorization(Roles.Common, Roles.Superuser, Roles.Administrator), Route("common")]
        public CustomResponse RequestForCommonUsers() {
            return new CustomResponse {
                Data = "Request for common users. Data is available for common users, superusers and administrators."
            };
        }

        [HttpGet, JwtApiAuthorization(Roles.Superuser, Roles.Administrator), Route("superuser")]
        public CustomResponse RequestForSuperusers() {
            return new CustomResponse {
                Data = "Request for anonymous users. Data is available superusers and administrators."
            };
        }

        [HttpGet, JwtApiAuthorization(Roles.Administrator), Route("administrator")]
        public CustomResponse RequestForAdministrators() {
            return new CustomResponse {
                Data = "Request for anonymous users. Data is available only for administrators."
            };
        }
    }
}