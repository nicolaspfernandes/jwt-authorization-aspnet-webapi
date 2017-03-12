namespace JwtWebApiAuthorization.Filters {

    using Token;

    using System.Linq;
    using System.Collections.Generic;

    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using System.Web.Http.Controllers;

    /// <summary>
    /// Class to support ActionFilterAttribute in order to control access to requests by given roles.
    /// </summary>
    public class JwtApiAuthorization : ActionFilterAttribute {

        /// <summary>
        /// Default constructor. Receives a list of roles that should be checked against authorization cookie.
        /// </summary>
        /// <param name="roles">List of roles.</param>
        public JwtApiAuthorization(params Roles[] roles) {
            Roles = new List<Roles>();
            Roles.AddRange(roles);
        }

        /// <summary>
        /// Overriding implementation of OnActionExecuting method. Checks if the rules matches with the 
        /// permissions allowed by the authorization token. If not, send the user right away to a forbidden page.
        /// </summary>
        /// <param name="filterContext">HttpActionContext instance to work with Http data.</param>
        public override void OnActionExecuting(HttpActionContext actionContext) {
            
            var authorizationToken = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();
            if (!CheckAccessTokenAgainstRoles(authorizationToken)) { 
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }

        /// <summary>
        /// Checks if the authorization token is valid and if the Roles list contains a specific role given by the token.
        /// </summary>
        /// <param name="authorizationToken">String token that contains information about access.</param>
        /// <returns>Boolean value informing if the permission can be granted or not.</returns>
        public bool CheckAccessTokenAgainstRoles(string authorizationToken) {

            bool permissionCanBeGranted = true;

            if (Roles.Count > 0 && !Roles.Contains(Token.Roles.Anonymous)) {
                if (!string.IsNullOrEmpty(authorizationToken)) {

                    var accessToken = new AccessToken(authorizationToken);
                    if (!accessToken.IsValid || !Roles.Contains(accessToken.Role)) {
                        permissionCanBeGranted = false;
                    }
                } else {
                    permissionCanBeGranted = false;
                }
            }

            return permissionCanBeGranted;
        }
        
        private List<Roles> Roles { get; set; }
    }
}