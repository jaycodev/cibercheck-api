using System.Security.Cryptography;

namespace CiberCheck.Features.Users.Security
{
    public static class PasswordHasher
    {
        // Hash format: {iterations}.{saltBase64}.{hashBase64}
        public static string Hash(string password, int iterations = 100_000)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                32);
            return string.Concat(iterations, '.', Convert.ToBase64String(salt), '.', Convert.ToBase64String(hash));
        }

        public static bool Verify(string password, string passwordHash)
        {
            var parts = passwordHash.Split('.');
            if (parts.Length != 3) return false;
            if (!int.TryParse(parts[0], out var iterations)) return false;
            var salt = Convert.FromBase64String(parts[1]);
            var expected = Convert.FromBase64String(parts[2]);

            var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
    }
}
