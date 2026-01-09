using FunDooBusiness.Services;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using FunDooBusiness.Interfaces;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FunDooTests
{
    public class AuthServiceTests
    {
        private Mock<IUserRepository> _userRepoMock;
        private Mock<IOtpService> _otpServiceMock;
        private Mock<IConfiguration> _configMock;
        private AuthService _authService;

        [SetUp]
        public void Setup()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _otpServiceMock = new Mock<IOtpService>();
            _configMock = new Mock<IConfiguration>();

            _configMock.Setup(x => x["Jwt:Key"])
                .Returns("THIS_IS_A_VERY_LONG_TEST_SECRET_KEY_123456");

            _configMock.Setup(x => x["Jwt:Issuer"])
                .Returns("TestIssuer");

            _configMock.Setup(x => x["Jwt:Audience"])
                .Returns("TestAudience");

            _authService = new AuthService(
                _userRepoMock.Object,
                _configMock.Object,
                _otpServiceMock.Object
            );
        }


        [Test]
        public void LoginAsync_ValidUser_ReturnsToken()
        {
            var user = new User
            {
                UserId = 1,
                Email = "test@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("1234"),
                IsEmailVerified = true
            };

            _userRepoMock.Setup(x => x.GetByEmailAsync("test@test.com"))
                         .ReturnsAsync(user);

            var token = _authService.LoginAsync("test@test.com", "1234").Result;

            Assert.NotNull(token);
        }
    }
}
