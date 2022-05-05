using Sample.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

//����ע��IdentityServer
var identytyServer = builder.Services.AddIdentityServer();
//���ǩ��ƾ��
identytyServer.AddDeveloperSigningCredential();

//ʹ���ڴ��е�����
identytyServer.AddInMemoryApiScopes(Config.ApiScopes);
identytyServer.AddInMemoryClients(Config.Clients);









var app = builder.Build();
app.UseIdentityServer();

app.Run();
