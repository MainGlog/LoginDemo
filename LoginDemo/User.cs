using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo
{
    public class User
    {
        public String Email { get; set; }
        public String Salt { get; private set; }
        public String HashedPwd { get; private set; }

        public User(String email, String password)
        {
            Email = email;
            Salt = CryptoUtils.GenerateSalt();
            HashedPwd = CryptoUtils.HashPassword(password, Salt);
        }
    }
}
