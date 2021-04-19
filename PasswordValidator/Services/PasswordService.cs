using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordValidator.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IList<char> _validSpecialCharacters = "!@#$%^&*()-+".ToCharArray();

        public bool IsValid(string password) =>
                HasMoreThan9Characters(password)
                && HasAtLeastOneDigit(password)
                && HasAtLeastOneUpperCaseChar(password)
                && HasAtLeastOneLowerCaseChar(password)
                && HasAValidSpecialChar(password)
                && DontHaveRepeatedChars(password);

        private bool HasMoreThan9Characters(string password) => password.Length >= 9;
        private bool HasAtLeastOneDigit(string password) => password.Any(char.IsDigit);
        private bool HasAtLeastOneUpperCaseChar(string password) => password.Any(char.IsUpper);
        private bool HasAtLeastOneLowerCaseChar(string password) => password.Any(char.IsLower);
        private bool HasAValidSpecialChar(string password) => password.Any(p => _validSpecialCharacters.Contains(p));
        private bool DontHaveRepeatedChars(string password) => !password.ToLowerInvariant().ToCharArray().GroupBy(e => e).Any(e => e.Count() > 1);
    }
}
