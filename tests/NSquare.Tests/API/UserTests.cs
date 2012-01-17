using System;
using NSquare.API;
using NUnit.Framework;

namespace NSquare.Tests.API
{
    public class UserTests
    {
        #region User ID, Equality and HashCode

        [Test]
        public void User_Has_Id_And_It_Must_Be_Readonly()
        {
            string userId = "156745487";
            User user = new User(userId);

            Assert.AreEqual(userId, user.Id);
        }

        [Test]
        public void When_User_Id_Is_Not_Provided_It_Must_Throws_Exception()
        {
            TestDelegate createUserWithNullableId = new TestDelegate(() => { new User(null); });
            TestDelegate createUserWithEmptyId = new TestDelegate(() => { new User(String.Empty); });

            Assert.Throws<ArgumentNullException>(createUserWithNullableId, "User ID cannot be null.");
            Assert.Throws<ArgumentException>(createUserWithEmptyId, "User ID cannot be empty.");
        }

        [Test]
        public void Users_Instances_With_Same_Id_Must_Be_Equal()
        {
            // Arrange
            string userId = "13579842";
            User firstUserInstance = new User(userId);
            User secondUserInstance = new User(userId);
            // Assert
            Assert.AreEqual(firstUserInstance, secondUserInstance);
        }

        [Test]
        public void Users_Instances_With_Unequal_Ids_Must_Not_Be_Equal()
        {
            // Arrange            
            User firstUserInstance = new User("13579842");
            User secondUserInstance = null;
            // Assert
            Assert.AreNotEqual(firstUserInstance, secondUserInstance);
        }

        [Test]
        public void Users_Instances_With_Equal_Ids_Must_Have_Same_HashCode()
        {
            // Arrange
            string userId = "13579842";
            User firstUserInstance = new User(userId);
            User secondUserInstance = new User(userId);
            // Act
            int firstHashCode = firstUserInstance.GetHashCode();
            int secondHashCode = secondUserInstance.GetHashCode();
            // Assert
            Assert.AreEqual(firstHashCode, secondHashCode);
        }

        #endregion

        #region User FirstName and LastName

        [Test]
        public void Users_Have_FirstName_And_LastName()
        {
            // Arrange
            User user = new User("5356321");
            string firstName = "John";
            string lastName = "Doe";
            // Act
            user.FirstName = firstName;
            user.LastName = lastName;
            // Assert
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void Users_FullName_Is_FirstName_With_LastName()
        {
            User user = new User("4568902");
            user.FirstName = "John   ";
            user.LastName = "    Doe";
            //
            Assert.AreEqual("John Doe", user.FullName);
        }

        #endregion
    }
}