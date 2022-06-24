using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//注册认证服务
builder.Services.AddAuthentication("Bearer")
    //Bearer认证方案
    .AddJwtBearer("Bearer", options =>
    {
        //配置委托
        //服务地址
        options.Authority = "https://localhost:7232";
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
//添加验证
app.UseAuthentication();
//授权中间件
app.UseAuthorization();
//.RequireAuthorization("Apiscope")所有控制器都要验证
app.MapControllers().RequireAuthorization("Apiscope");

app.Run();
