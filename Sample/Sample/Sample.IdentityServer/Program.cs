using Sample.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()//����ע��IdentityServer
    .AddDeveloperSigningCredential()//���ǩ��ƾ��
    .AddInMemoryApiScopes(Config.ApiScopes)//ʹ���ڴ��е�����
    .AddInMemoryClients(Config.Clients)//ʹ���ڴ��е�����
    .AddTestUsers(Config.Users);

var app = builder.Build();

app.UseIdentityServer();
app.Run(); 
