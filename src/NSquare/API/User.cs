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
    }
}