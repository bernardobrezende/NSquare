using System;
using Amarok.Framework.Contracts;

namespace NSquare.API
{
    public class User
    {
        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return String.Format("{0} {1}", this.FirstName.Trim(), this.LastName.Trim()); } }

        public User(string id)
        {
            Ensure.That(id).IsNotNull().Otherwise.Throw<ArgumentNullException>("User ID cannot be null.");
            Ensure.That(!id.Equals(String.Empty)).Otherwise.Throw<ArgumentException>("User ID cannot be empty.");
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            User otherUser = obj as User;
            return otherUser != null && this.Id.Equals(otherUser.Id, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return 49 ^ Id.GetHashCode();
        }
    }
}