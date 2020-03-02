using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    internal class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> {
               new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "anbinhtrong",
                    Password = "password123",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "anbinhtrong@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
               }
             };
        }
    }
}
