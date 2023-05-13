using Expenses.Server.DTO;
using Expenses.Server.Entities;
using Expenses.Server.Repositories;
using Expenses.Server.Services;

namespace Expenses.Server.Tests
{
    public class UnitTest1 : IDisposable
    {

        private readonly SharedFixture _databaseFixture;
        public UnitTest1()
        {
            _databaseFixture = new SharedFixture();
        }

        public void Dispose()
        {
            _databaseFixture.Dispose();
        }

        [Fact]
        public void TestRegister()
        {
            var userDTO = new UserDTO
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Testabc",
            };
            var userService = new UserService(new BaseRepository<User>(_databaseFixture.CreateContext()));
            var user = userService.Register(userDTO);
            Assert.NotNull(user);

        }

        [Fact]
        public void TestSuccessLogin()
        {

            var userDTO = new UserDTO
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Testabc",
            };
            var userService = new UserService(new BaseRepository<User>(_databaseFixture.CreateContext()));
            var user = userService.Register(userDTO);

            userDTO = new UserDTO
            {
                Email = "Test",
                Password = "Testabc",
            };
            var result = userService.Login(userDTO);
            Assert.True(result.Item1);

        }

        [Fact]
        public void TestFailedLogin()
        {
            var userDTO = new UserDTO
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Testabc",
            };
            var userService = new UserService(new BaseRepository<User>(_databaseFixture.CreateContext()));
            _ = userService.Register(userDTO);

            userDTO = new UserDTO
            {
                Email = "Test",
                Password = "Testabc",
            };

            var result = userService.Login(userDTO);
            Assert.False(result.Item1);
            Assert.True(!string.IsNullOrEmpty(result.Item2));
            Assert.Null(result.Item3);

        }
    }
}