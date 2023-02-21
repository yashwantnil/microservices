using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        //Define Our Api Scopes
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api1", "MyAPI")
            };

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //    new IdentityResource[]
        //    {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //    };
        //public static IEnumerable<ApiScope> ApiScopes =>
        //     new ApiScope[]
        //     {
        //        new ApiScope("myApi.read"),
        //        new ApiScope("myApi.write"),
        //     };
        //public static IEnumerable<ApiResource> ApiResources =>
        //    new ApiResource[]
        //    {
        //       new ApiResource("myApi")
        //       {
        //        Scopes = new List<string>{ "myApi.read","myApi.write" },
        //        ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
        //       }
        //    };

        // Define Our Clients i.e any software that can make a request to access our resource(Web APIs)..
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "userMgt.client",
                    ClientName = "AdminClient",
                    //username and password is required...
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // scopes that client has access to  i.e the apis the clients have access to
                    AllowedScopes = { "api1" }
                },
                //new Client
                //{
                //    ClientId = "movieMgt.client",
                //    ClientName = "Movie Mgt MicroService",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                //    ClientSecrets = 
                //    { 
                //        new Secret("secret".Sha256()) 
                //    },
                //    //scopes that client has access to i.e the apis the clients have access to
                //    AllowedScopes = { "myApi.read" }
                //},
            };
        //Define Our Test Users ...TestUser Model is located in the IdentityServer4
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1144",
                    Username = "ola@gmail.com",
                    Password = "password",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Adu"),
                        new Claim(JwtClaimTypes.GivenName, "Sunkanmi"),
                        new Claim(JwtClaimTypes.Role, "Admin"),
                        new Claim(JwtClaimTypes.WebSite, "https://localhost:7126/connect/token"),
                    }
                },

                new TestUser
                {
                    SubjectId = "1144",
                    Username = "shenor@gmail.com",
                    Password = "password",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "TemiTope"),
                        new Claim(JwtClaimTypes.GivenName, "Darasimi"),
                        new Claim(JwtClaimTypes.Role, "User"),
                        new Claim(JwtClaimTypes.WebSite, "https://localhost:7126/connect/token"),
                    }
                }
            };






    }
}
