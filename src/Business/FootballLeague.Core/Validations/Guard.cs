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
    }
}
