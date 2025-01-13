using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Domain.Abstraction;

namespace Bookify.Domain.Users
{
    public sealed class User(Guid id) : Entity(id)
    {
        private User(Guid id, LastName lastName, FirstName firstName, Email email) : this(id)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
        }

        public LastName LastName { get; private set; }
        public FirstName FirstName { get;private set; }
        public Email Email { get; private set; }

        public static User Create(FirstName firstName, LastName lastName, Email email)
        {
            if(string.IsNullOrWhiteSpace(firstName.Value)||string.IsNullOrWhiteSpace(lastName.Value)||string.Format())
        }

    }
}
