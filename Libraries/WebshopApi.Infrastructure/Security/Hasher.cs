//using Microsoft.AspNet.Identity;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using WebshopApi.Domain.Services;

//namespace WebshopApi.Infrastructure.Security
//{
//    //public abstract class Hasher : IHasher
//    //{
//    //    public string HashPasswordAsync(string password)
//    //    {
//    //        byte[] salt = new byte[128 / 8];
//    //        using (var rng = RandomNumberGenerator.Create())
//    //        {
//    //            rng.GetBytes(salt);
//    //        }

//    //        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//    //            password: password,
//    //            salt: salt,
//    //            prf: KeyDerivationPrf.HMACSHA256,
//    //            iterationCount: 10000,
//    //            numBytesRequested: 256 / 8));

//    //        return $"{hashed}:{Convert.ToBase64String(salt)}";
//    //    }

//    //    public bool VerifyPassword(string password, string hashedPassword)
//    //    {
//    //        string[] hashParts = hashedPassword.Split(':');
//    //        byte[] salt = Convert.FromBase64String(hashParts[1]);
//    //        string hash = hashParts[0];

//    //        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//    //            password: password,
//    //            salt: salt,
//    //            prf: KeyDerivationPrf.HMACSHA256,
//    //            iterationCount: 10000,
//    //            numBytesRequested: 256 / 8));

//    //        return hash == hashed;
//    //    }

       
//    }
//}
