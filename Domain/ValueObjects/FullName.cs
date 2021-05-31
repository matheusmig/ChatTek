using Domain.Common;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public sealed class FullName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        public FullName(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
