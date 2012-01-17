using System;
using Amarok.Framework.Contracts;

namespace NSquare.API
{
    public class User
    {
        public string Id { get; private set; }

        public User(string id)
        {
            Ensure.That(id).IsNotNull().Otherwise.Throw<ArgumentNullException>();
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            User otherUser = obj as User;
            return otherUser != null && this.Id.Equals(otherUser.Id, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}