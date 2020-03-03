using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Configurations
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credential Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("superSecretPassword".Sha256()) // Create secrect password
                    },
                    AllowedScopes = new List<string> {"customAPI.read"}
                }
            };
        }
    }
}
