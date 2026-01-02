namespace BackendMastery.ProdReadiness.Authentication.Contracts;

/// WHY: Captures user credentials.
/// USE CASE: Human identity proof.
/// WARNING: Never log or persist raw passwords.
public sealed record LoginRequest(
    string Username,
    string Password);