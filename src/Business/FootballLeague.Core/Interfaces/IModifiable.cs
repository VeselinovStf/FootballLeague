using System;

namespace FootballLeague.Core.Interfaces
{
    public interface IModifiable
    {
        public DateTime? ModifiedAt { get; set; }
    }
}
