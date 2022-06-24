using Sample.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

////����ע��IdentityServer
//var identytyServer = builder.Services.AddIdentityServer();
////���ǩ��ƾ��
//identytyServer.AddDeveloperSigningCredential();

////ʹ���ڴ��е�����
//identytyServer.AddInMemoryApiScopes(Config.ApiScopes);
//identytyServer.AddInMemoryClients(Config.Clients);

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddTestUsers(Config.Users);









var app = builder.Build();
app.UseIdentityServer();

app.Run();
