using Sample.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

//依赖注入IdentityServer
var identytyServer = builder.Services.AddIdentityServer();
//添加签名凭据
identytyServer.AddDeveloperSigningCredential();

//使用内存中的配置
identytyServer.AddInMemoryApiScopes(Config.ApiScopes);
identytyServer.AddInMemoryClients(Config.Clients);









var app = builder.Build();
app.UseIdentityServer();

app.Run();
