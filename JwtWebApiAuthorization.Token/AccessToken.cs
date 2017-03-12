namespace JwtWebApiAuthorization.Token {

    using JWT;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Access Token class, created for generate and decode JWT token strings.
    /// </summary>
    public class AccessToken {

        /// <summary>
        /// Default constructor. Starts the IsValid attribute with true (the object is valid by default) and the Starter date as 1970-1-1.
        /// </summary>
        public AccessToken() {
            IsValid = true;
            TokenExpiration = TokenExpirations.Daily;
            StarterDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        /// <summary>
        /// Constructor overloading to receive the information will be mocked in the authorization token and the rule available for this token.
        /// </summary>
        /// <param name="information">Information will be mocked into the token.</param>
        /// <param name="role">Role that grants specific permission to the user.</param>
        /// <param name="tokenExpiration">Optional. How long is token duration.</param>
        public AccessToken(object information, Roles role = Roles.Anonymous, TokenExpirations tokenExpiration = TokenExpirations.Hourly) : this() {
            Role = role;
            Information = information;
            TokenExpiration = tokenExpiration;
        }

        /// <summary>
        /// Constructor overloading to receive a token, decode it and set the object's attributes with the given values.
        /// </summary>
        /// <param name="accessToken"></param>
        public AccessToken(string accessToken) : this() {

            try {

                var token = JsonWebToken.DecodeToObject<AccessToken>(accessToken, TokenUtilities.TokenSecretKey);
                Role = token.Role;
                Information = token.Information;
                TokenExpiration = token.TokenExpiration;

            } catch (SignatureVerificationException) {
                IsValid = false;
            }
        }
        
        /// <summary>
        /// Encodes a token to JWT by using secret key + a given algorithm.
        /// </summary>
        /// <param name="algorithm">Algorithm used for encoding. Default value is HS512.</param>
        /// <returns></returns>
        public string ToTokenString(JwtHashAlgorithm algorithm = JwtHashAlgorithm.HS512) {

            ExpirationDate = DateTime.Now.AddMinutes((int) TokenExpiration);
            ExpirationTime = Math.Round((ExpirationDate - StarterDate).TotalSeconds);

            return JsonWebToken.Encode(new Dictionary<string, object> {
                { "exp", ExpirationTime },
                { "Role", Role },
                { "Information", Information },
                { "TokenExpiration", TokenExpiration }
            }, TokenUtilities.TokenSecretKey, algorithm);
        }
        
        public bool IsValid { get; set; }
        public DateTime StarterDate { get; set; }
        public double ExpirationTime { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Roles Role { get; set; }
        public object Information { get; set; }
        public TokenExpirations TokenExpiration { get; set; }
    }
}