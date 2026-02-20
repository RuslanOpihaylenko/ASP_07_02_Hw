using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class UserHashings
    {
        public static string Hash(string password)
        {
           return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
        public static bool Verify(string password, string hash) 
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
    }
}
