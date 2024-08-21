namespace VelorusNet8.Domain.Entities.Common.ValueObjects;

public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, null) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        using (var thisValues = GetEqualityComponents().GetEnumerator())
        using (var otherValues = other.GetEqualityComponents().GetEnumerator())
        {
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
    }

    public override int GetHashCode()
    {
        unchecked // Allow overflow
        {
            return GetEqualityComponents()
                .Aggregate(0, (current, obj) =>
                {
                    return current * 31 ^ (obj == null ? 0 : obj.GetHashCode());
                });
        }
    }
}
