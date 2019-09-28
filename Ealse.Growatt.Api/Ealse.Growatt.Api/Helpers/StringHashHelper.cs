using System.Security.Cryptography;
using System.Text;

namespace Ealse.Growatt.Api.Helpers
{
    public static class StringHashHelper
    {
        public static string CalculateMD5Hash(this string s)
        {
            using (var provider = MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                {
                    var result = b.ToString("x2").ToLower();
                    // foreach byte the first character '0' is replaced by the character 'c' by Growatt
                    var changedResult = result[0].Equals('0') ? $"c{result[1]}" : null;

                    builder.Append(changedResult ?? result);
                }

                return builder.ToString();
            }
        }
    }
}
