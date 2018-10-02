using System.Collections.Generic;

namespace Corenet.Core
{
    public interface IValueObject
    {
        IEnumerable<object> GetAttributesToIncludeInEqualityCheck();
    }
}