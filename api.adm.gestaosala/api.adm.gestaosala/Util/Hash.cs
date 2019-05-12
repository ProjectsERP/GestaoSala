using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace api.adm.gestaosala.Util
{
#pragma warning disable CS1591
    public class Hash
    {
        public static string GerarHash(string text)
        {
            SHA256 sha = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("x"));
            }
            return result.ToString();
        }
    }
#pragma warning disable CS1591
}
