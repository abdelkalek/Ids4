using IdentityServer4.Models;
using System.Collections.Generic;

namespace Ids4
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new[]
                {
                    new ApiScope("apiscope", "Access to ProtectedResource.Scope1"),
                };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {

         

            return new List<ApiResource>
            {

                new ApiResource("myresourceapi", "My Resource API")
                {
                        
                           Scopes = { "apiscope"}

                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // for public api
                new Client
                {
                    ClientId = "secret_client_id",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "apiscope" }
                }
            };
        }
    }
}