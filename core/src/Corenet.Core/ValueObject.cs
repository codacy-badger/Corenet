using System;
using System.Collections.Generic;
using System.Linq;

namespace Corenet.Core
{
    public abstract class ValueObject<T> : IValueObject, IEquatable<ValueObject<T>> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj is ValueObject<T> valueObject)
                return Equals(valueObject);
            return false;
        }

        public bool Equals(ValueObject<T> other)
        {
            if (other is null) return false;
            return GetAttributesToIncludeInEqualityCheck()
                .SequenceEqual(
                    other.GetAttributesToIncludeInEqualityCheck()
                    );
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => left.Equals(right);

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !(left == right);

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (object obj in GetAttributesToIncludeInEqualityCheck())
                hash = hash * 31 + (obj?.GetHashCode() ?? 0);
            return hash;
        }

        public abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();
    }
}
