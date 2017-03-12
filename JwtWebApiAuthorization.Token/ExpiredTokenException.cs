namespace JwtWebApiAuthorization.Token {

    using System;

    /// <summary>
    /// Exception that will be thrown in case of the token be expired.
    /// </summary>
    public class ExpiredTokenException : Exception {
        public ExpiredTokenException(Exception innerException) :
            base("Invalid token. Key doesn't match and/or token validation expired.", innerException) { }
    }
}
