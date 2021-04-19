using System;
using System.Collections.Generic;
using PasswordValidator.Services;
using Xunit;

namespace PasswordValidatorTests.Unit.Services
{
    public class PasswordServiceTest
    {

        [Fact]
        public void IsValid_WithValidPassword_ReturnsTrue()
        {
            var service = new PasswordService();
            var validPassword = "AbTp9!fok";

            var result = service.IsValid(validPassword);

            Assert.True(result);
        }

        [Fact]
        public void IsValid_WithLessThanNineCharacters_ReturnsFalse()
        {
            var service = new PasswordService();
            var invalidPassword = "a2C4e6G8";

            var result = service.IsValid(invalidPassword);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WithoutAtLeastOneNumber_ReturnsFalse()
        {
            var service = new PasswordService();
            var invalidPassword = "abcdefghi";

            var result = service.IsValid(invalidPassword);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WithoutAnUpperCaseChar_ReturnsFalse()
        {
            var service = new PasswordService();
            var invalidPassword = "abcdefgh1";

            var result = service.IsValid(invalidPassword);

            Assert.False(result);
        }

        [Fact]
        public void IsValid_WithoutALowerCaseChar_ReturnsFalse()
        {
            var service = new PasswordService();
            var invalidPassword = "ABCDEFGH1";

            var result = service.IsValid(invalidPassword);

            Assert.False(result);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("/")]
        [InlineData("|")]
        [InlineData("~")]
        public void IsValid_WithoutASpecialCharWithinASpecificRange_ReturnsFalse(string invalidSpecialChar)
        {
            var service = new PasswordService();
            var invalidPassword = "AbCdEfG1".Insert(0, invalidSpecialChar);

            var result = service.IsValid(invalidPassword);

            Assert.False(result);
        }

        [Theory]
        [InlineData("Ab!Cd#Ee1")]
        [InlineData("Ab!Cd#ee1")]
        [InlineData("Ab!Cd#EA1")]
        [InlineData("Ab!Cd#Ed1")]
        public void IsValid_WithRepeatedCharacters_ReturnsFalse(string invalidPassword)
        {
            var service = new PasswordService();

            var result = service.IsValid(invalidPassword);

            Assert.False(result);
        }
    }
}
