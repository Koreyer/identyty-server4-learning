using Sample.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()//依赖注入IdentityServer
    .AddDeveloperSigningCredential()//添加签名凭据
    .AddInMemoryApiScopes(Config.ApiScopes)//使用内存中的配置
    .AddInMemoryClients(Config.Clients)//使用内存中的配置
    .AddTestUsers(Config.Users);

var app = builder.Build();

app.UseIdentityServer();
app.Run(); 
