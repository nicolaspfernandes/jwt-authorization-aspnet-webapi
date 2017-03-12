namespace JwtWebApiAuthorization.Token {

    /// <summary>
    /// Enum with expiration types in minutes that will be used for control token's lifetime.
    /// </summary>
    public enum TokenExpirations {
        
        TenMinutes = 10,
        ThirtyMinutes = 30,
        Hourly = 60,
        Daily = 1440,
        Weekly = 10080,
        Monthly = 43200
    }
}