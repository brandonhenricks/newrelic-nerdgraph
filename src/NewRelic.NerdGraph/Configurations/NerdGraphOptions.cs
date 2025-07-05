namespace NewRelic.NerdGraph.Configurations
{
    /// <summary>
    /// Represents configuration options for connecting to the New Relic NerdGraph API.
    /// </summary>
    public class NerdGraphOptions
    {
        /// <summary>
        /// Gets or sets the API key used for authenticating requests to the NerdGraph API.
        /// </summary>
        public string ApiKey { get; set; } = default!;

        /// <summary>
        /// Gets or sets the endpoint URL for the NerdGraph API.
        /// Defaults to the US region endpoint.
        /// </summary>
        public string Endpoint { get; set; } = "https://api.newrelic.com/graphql"; // Default to US

        /// <summary>
        /// Gets or sets the timeout duration for API requests.
        /// Defaults to 30 seconds.
        /// </summary>
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
    }
}
