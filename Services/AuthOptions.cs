﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OskiTest.Services
{
    #pragma warning disable CS1591
    public class AuthOptions
    {
        public const string ISSUER = "http://localhost:5215"; // издатель токена
        public const string AUDIENCE = "https://qtzkzc.csb.app/"; // потребитель токена
        const string KEY = "103g5779e7423w32"; // ключ для шифрации
        public const int LIFETIME = 15; // время жизни токена минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
