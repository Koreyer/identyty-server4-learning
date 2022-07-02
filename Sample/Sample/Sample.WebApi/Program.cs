using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注册认证服务
//Bearer认证方案
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        //配置委托
        //服务地址
        options.Authority = "https://localhost:7199";
        //验证参数  默认不需要吧
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", builder =>
    {
        //是否通过前面的认证
        builder.RequireAuthenticatedUser();
        //鉴定api范围
        builder.RequireClaim("scope", "sample_api");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//将身份验证中间件添加到管道中，以便在每次调用主机时自动执行身份验证。
app.UseAuthentication();
//添加授权中间件以确保匿名客户端无法访问我们的 API 端点。
app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
//所有控制器都要验证
app.MapControllers().RequireAuthorization("Apiscope");

app.Run();
