using System;
using Xunit;
using PasswordValidator.Controllers;
using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Services;
using Moq;

namespace PasswordValidatorTests.Unit.Controllers
{
    public class PasswordControllerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValid_WithInvalidRequestValue_ReturnsBadRequest(string value)
        {
            var controller = new PasswordController(passwordService: null);

            var result = controller.IsValid(value);

            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public void IsValid_WithValidRequestValue_CallsPasswordService()
        {
            var mockPasswordService = new Mock<IPasswordService>();
            var controller = new PasswordController(mockPasswordService.Object);
            var validPassword = "a";

            controller.IsValid(validPassword);

            mockPasswordService.Verify(mock => mock.IsValid(validPassword), Times.Once());
        }

        [Fact]
        public void IsValid_WithValidPassword_ReturnsTrue()
        {
            var validPassword = "AbTp9!fok";
            var passwordService = new Mock<IPasswordService>();
            passwordService
                .Setup(e => e.IsValid(validPassword))
                .Returns(true);
            var controller = new PasswordController(passwordService.Object);

            var result = controller.IsValid(validPassword);

            Assert.True(result.Value);
        }

        [Fact]
        public void IsValid_WithInvalidPassword_ReturnsFalse()
        {
            var invalidPassword = "AAAbbbCCC";

            var passwordService = new Mock<IPasswordService>();
            passwordService
                .Setup(e => e.IsValid(invalidPassword))
                .Returns(false);
            var controller = new PasswordController(passwordService.Object);

            var result = controller.IsValid(invalidPassword);

            Assert.False(result.Value);
        }
    }
}
