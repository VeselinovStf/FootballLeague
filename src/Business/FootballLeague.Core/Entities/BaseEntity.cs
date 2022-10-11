using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeague.Core.Entities
{
    public class BaseEntity : ICreatable, IModifiable, IDeletable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public List<BaseDomainEvent> Events { get; set; } = new List<BaseDomainEvent>();
    }
}
