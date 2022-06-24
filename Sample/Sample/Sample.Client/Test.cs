using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Client
{
    public class Test
    {
        public async Task Get()
        {

            //通过IdentityServer获取token
            var client = new HttpClient();
            //获取发现文档
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7232");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "sample_client",
                    ClientSecret = "sample_client_secret"
                });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);


            //根据token调用api
            var apiClient = new HttpClient();
            //设置请求头
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            //请求方法
            var response = await apiClient.GetAsync("https://localhost:7231/demo/get");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JArray.Parse(content));
            
        }
    }
}
