namespace TAL.PremiumCalculator.API
{
    /// <summary>
    /// Constants
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Key for connection string app setting
        /// </summary>
        public const string CONNECTION_STRING_KEY = "PremiumCalculatorConnection";

        /// <summary>
        /// Key for cors origins app setting
        /// </summary>
        public const string CORS_ORIGINS_KEY = "AllowedOrigins";

        /// <summary>
        /// Generic retrieval error prefix
        /// </summary>
        public const string RETRIEVE_ERROR_MESSAGE = "Could not retrieve {0}";

        /// <summary>
        /// Name of (production) cors policy
        /// </summary>
        public const string CORS_POLICY_NAME = "CorsPolicy";

        /// <summary>
        /// Delimiter used to split cors origins when multiple are required
        /// </summary>
        public const string CORS_ORIGINS_DELIMITER = ";";
    }
}
