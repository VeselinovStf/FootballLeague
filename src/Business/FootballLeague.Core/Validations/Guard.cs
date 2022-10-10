using FootballLeague.Core.Entities;
using FootballLeague.Core.Exceptions;
using System;

namespace FootballLeague.Core.Validations
{
    public static class Guard
    {
        public static void ValueLessThenEqual(int limit, int value)
        {
            if (value <= limit)
            {
                throw new ValidationException($"Value is less than equal to: {limit}");
            }
        }

        internal static void NotNull<T>(T obj)
        {
            if (obj == null)
            {
                throw new ValidationException("Object is null");
            }
        }

        internal static void StringIsNullEmptyOrWhiteSpace(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException($"Invalid {nameof(name)}, must be a valid string");
            }
        }
    }
}
