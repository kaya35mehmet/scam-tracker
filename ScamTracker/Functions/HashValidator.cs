using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public static class HashValidator
{
    public static bool IsValidHash(string hash)
    {
        return Regex.IsMatch(hash, "^[a-fA-F0-9]{64}$");
    }

    public static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public static bool VerifyHash(string input, string hash)
    {
        string computedHash = ComputeSha256Hash(input);
        return computedHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
    }

    public static string GetShortenedHash(string hash)
    {
        if (hash.Length <= 16)
        {
            return hash;
        }

        string start = hash.Substring(0, 8);
        string end = hash.Substring(hash.Length - 8, 8);

        return $"{start}...{end}";
    }
}