// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using Xunit;

namespace Corenet.Core.Tests
{
    public class ValueObject_Tests
    {
        [Fact]
        public void Equals_RightObjectIsNull_ShouldReturnFalse()
        {
            ValueObjectMock mock1 = new ValueObjectMock { MockString = "value", MockInt = 26 };
            ValueObjectMock mock2 = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            bool actual = mock1.Equals(mock2);

            Assert.False(actual);
        }

        [Fact]
        public void Equals_ValuesObjectsOfSameTypeWithDifferentValues_ShouldReturnFalse()
        {
            ValueObjectMock mock1 = new ValueObjectMock { MockString = "value", MockInt = 26 };
            ValueObjectMock mock2 = new ValueObjectMock { MockString = "value", MockInt = 27 };
            bool actual = mock1.Equals(mock2);

            Assert.False(actual);
        }

        [Fact]
        public void Equals_ValuesObjectsOfSameTypeWithSameValues_ShouldReturnTrue()
        {
            ValueObjectMock mock1 = new ValueObjectMock { MockString = "value", MockInt = 26 };
            ValueObjectMock mock2 = new ValueObjectMock { MockString = "value", MockInt = 26 };

            Assert.True(mock1.Equals(mock2));
        }

        [Fact]
        public void Equals_ValuesObjectAndNullDifferentType_ShouldReturnFalse()
        {
            ValueObjectMock mock1 = new ValueObjectMock { MockString = "value", MockInt = 26 };
            object mock2 = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            bool actual = mock1.Equals(mock2);

            Assert.False(actual);
        }

        [Fact]
        public void Equals_ValuesObjectAndDifferentType_ShouldReturnFalse()
        {
            ValueObjectMock mock1 = new ValueObjectMock { MockString = "value", MockInt = 26 };
            int mock2 = 0;
            // ReSharper disable once SuspiciousTypeConversion.Global
            bool actual = mock1.Equals(mock2);

            Assert.False(actual);
        }

        [Fact]
        public void Equals_ValuesObjectsOfSameTypeWithDifferentValuesButNotIncludedInGetAttributesToIncludeInEqualityCheck_ShouldReturnTrue()
        {
            ValueObjectMock mock1 = new ValueObjectMock { MockString = "value", MockInt = 26, MockDate = DateTime.MaxValue };
            ValueObjectMock mock2 = new ValueObjectMock { MockString = "value", MockInt = 26, MockDate = DateTime.MinValue };
            bool actual = mock1.Equals(mock2);

            Assert.True(actual);
        }
    }

    internal class ValueObjectMock : ValueObject<ValueObjectMock>
    {
        public string MockString { get; set; }
        public int MockInt { get; set; }
        public DateTime MockDate { get; set; }

        public override IEnumerable<object> GetAttributesToIncludeInEqualityCheck() => new object[] { MockString, MockInt };
    }
}
