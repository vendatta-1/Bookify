namespace Bookify.Domain.Common;

public record Currency
{
    public static readonly Currency USD = new("USD");
    public static readonly Currency EUR = new("EUR");
    internal static readonly Currency None = new("");

    public string CurrencyCode { get; init; }
    private Currency(string code) => CurrencyCode = code;

    public static Currency FromCode(string code)
        => All.FirstOrDefault(c => c.CurrencyCode == code) ??
           throw new ArgumentOutOfRangeException($"There is non code exist match with the provided code:{code}");

    public static IReadOnlyCollection<Currency> All
        = new[]
        {
            USD, EUR
        };
}