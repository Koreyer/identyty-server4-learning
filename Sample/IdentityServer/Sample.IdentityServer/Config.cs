using IdentityServer4.Models;

namespace Sample.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            //至少一个
            new ApiScope
            {
                //标志api范围的名称
                Name="sample_api",
                //显示名称，对api范围进行描述
                DisplayName = "Sample API"
            }
        };
        //客户端应用
        public static IEnumerable<Client> Clients => new[]
        {
            new Client
            {
                //客户端id
                ClientId = "sample_client",
                //客户端密钥
                ClientSecrets =
                {
                    //可以有多个  需要sha256加密
                    new Secret("sample_client_secret".Sha256())
                },
                //客户端凭据 指定授权类型
                AllowedGrantTypes =  GrantTypes.ClientCredentials,
                //允许的api范围
                AllowedScopes = { "sample_api" }
            }
        };
    }
}
