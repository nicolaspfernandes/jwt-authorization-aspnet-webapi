namespace JwtWebApiAuthorization.Token {

    /// <summary>
    /// Enum with roles that will be available for the application and will be used for authorization process.
    /// </summary>
    public enum Roles {
        None = 0,
        Anonymous = 1,
        Common = 2,
        Superuser = 3,
        Administrator = 4,
    }
}
