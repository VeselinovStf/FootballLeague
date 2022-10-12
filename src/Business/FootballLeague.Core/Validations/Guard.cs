using FootballLeague.Core.Exceptions;

namespace FootballLeague.Core.Validations
{
    public static class Guard
    {
        public static void ValueLessThenEqual(int limit, int value)
        {
            if (value <= limit)
            {
                throw new ValidationException($"Value, {value} is less than equal to: {limit}");
            }
        }

        public static void NotNull<T>(T obj)
        {
            if (obj == null)
            {
                throw new ValidationException($"{typeof(T)} is null/not found");
            }
        }

        public static void StringIsNullEmptyOrWhiteSpace(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException($"Invalid {nameof(name)}, must be a valid string");
            }
        }
    }
}
