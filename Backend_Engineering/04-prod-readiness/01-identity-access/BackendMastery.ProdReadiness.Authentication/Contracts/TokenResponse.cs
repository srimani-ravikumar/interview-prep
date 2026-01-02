namespace BackendMastery.ProdReadiness.Authentication.Contracts;

/// WHY: Represents a token issued after authentication.
/// USE CASE: Client consumes token for subsequent requests.
/// WARNING: Token must be stored securely by clients.
public sealed record TokenResponse(string AccessToken);