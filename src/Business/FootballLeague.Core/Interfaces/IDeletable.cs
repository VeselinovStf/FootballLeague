using System;

namespace FootballLeague.Core.Interfaces
{
    public interface IDeletable
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
