using System;
using NSquare.API;
using NUnit.Framework;

namespace NSquare.Tests.API
{
    public class UserTests
    {
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

            Assert.Throws<ArgumentNullException>(createUserWithNullableId);
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
    }
}