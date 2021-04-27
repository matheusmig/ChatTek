using ChatTek.Models.Common;
using System;

namespace ChatTek.Models
{
    public class Participant : Entity
    {
        public Participant(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
