namespace Frapid.Account
{
    public static class PasswordManager
    {
        public static bool ValidateBcrypt(string userName, string plainPassword, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword)  || string.IsNullOrWhiteSpace(hashedPassword))
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(userName + plainPassword, hashedPassword);
        }

        public static string GetHashedPassword(string userName, string plainPassword)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            return BCrypt.Net.BCrypt.HashPassword(userName + plainPassword, salt);
        }
    }
}