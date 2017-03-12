namespace JwtWebApiAuthorization {

    using System.Web.Http;
    using System.Web.Http.Cors;

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {

            // Web API routes
            config.EnableCors(new EnableCorsAttribute("http://localhost:11111/", "*", "*"));
            config.MapHttpAttributeRoutes();
        }
    }
}
