using FootballLeague.Core.Interfaces;
using System;

namespace FootballLeague.Core.Entities
{
    public class BaseEntity : ICreatable, IModifiable, IDeletable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
