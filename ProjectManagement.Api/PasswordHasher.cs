using System.Security.Cryptography;

public class PasswordHasher
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32;  // 256 bit
    private const int Iterations = 10000;

    public static string HashPassword(string password)
    {
        var salt = new byte[SaltSize];
        RandomNumberGenerator.Fill(salt);

        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            var key = pbkdf2.GetBytes(KeySize);
            var saltKey = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, saltKey, 0, SaltSize);
            Array.Copy(key, 0, saltKey, SaltSize, KeySize);

            return Convert.ToBase64String(saltKey);
        }
    }

    public static bool VerifyPassword(string hashedPassword, string inputPassword)
    {
        var saltKey = Convert.FromBase64String(hashedPassword);

        var salt = new byte[SaltSize];
        Array.Copy(saltKey, 0, salt, 0, SaltSize);

        using (var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, Iterations, HashAlgorithmName.SHA256))
        {
            var key = pbkdf2.GetBytes(KeySize);
            for (int i = 0; i < KeySize; i++)
            {
                if (saltKey[i + SaltSize] != key[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
