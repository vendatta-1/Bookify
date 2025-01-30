namespace Bookify.Domain.Common;

public record Money(decimal Amount, Currency Currency)
{

    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new InvalidOperationException("Currencies must to be equals");
        }

        return left with { Amount = left.Amount + right.Amount };
    }
    public virtual bool Equals(Money? other)
    {
        if (other is null)
            return false;
        return Amount == other.Amount && Currency == other.Currency;
    }
    public bool IsZero() => this == Zero(Currency);

    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new(0, currency);
}