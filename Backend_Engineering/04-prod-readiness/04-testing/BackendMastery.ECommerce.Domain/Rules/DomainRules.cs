namespace BackendMastery.ECommerce.Domain.Rules;

/// <summary>
/// Central place to document domain invariants.
/// Not all rules need code — some need visibility.
/// </summary>
public static class DomainRules
{
    public const string ProductMustHaveName =
        "A product must always have a name";

    public const string QuantityMustBePositive =
        "Quantity must be greater than zero";

    public const string MoneyCannotBeNegative =
        "Money amount cannot be negative";
}