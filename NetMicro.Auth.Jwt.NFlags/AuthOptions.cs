namespace NetMicro.Auth.Jwt.NFlags
{
    public static class AuthOptions
    {
        public const string AccessTokenName = "Access";
        public const string RefreshTokenName = "Refresh";

        public const string TokenPublicKeySuffix = "-token-public-key";
        public const string TokenPrivateKeySuffix = "-token-private-key";
        public const string TokenSecretSuffix = "-token-secret";

        public const string AccessTokenPublicKey = "access-token-public-key";
        public const string AccessTokenPrivateKey = "access-token-private-key";
        public const string AccessTokenSecret = "access-token-secret";

        public const string RefreshTokenPublicKey = "refresh-token-public-key";
        public const string RefreshTokenPrivateKey = "refresh-token-private-key";
        public const string RefreshTokenSecret = "refresh-token-secret";
        public const string DisableAuth = "disable-auth";

        public static string CreateTokenPublicKeyOptionName(string tokenName)
        {
            return tokenName.ToLower() + TokenPublicKeySuffix;
        }

        public static string CreateTokenPrivateKeyOptionName(string tokenName)
        {
            return tokenName.ToLower() + TokenPrivateKeySuffix;
        }

        public static string CreateTokenSecretOptionName(string tokenName)
        {
            return tokenName.ToLower() + TokenSecretSuffix;
        }
    }
}