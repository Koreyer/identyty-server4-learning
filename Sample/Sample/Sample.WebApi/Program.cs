using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ע����֤����
//Bearer��֤����
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        //����ί��
        //�����ַ
        options.Authority = "https://localhost:7199";
        //��֤����  Ĭ�ϲ���Ҫ��
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", builder =>
    {
        //�Ƿ�ͨ��ǰ�����֤
        builder.RequireAuthenticatedUser();
        //����api��Χ
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

//�������֤�м����ӵ��ܵ��У��Ա���ÿ�ε�������ʱ�Զ�ִ�������֤��
app.UseAuthentication();
//�����Ȩ�м����ȷ�������ͻ����޷��������ǵ� API �˵㡣
app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
//���п�������Ҫ��֤
app.MapControllers().RequireAuthorization("Apiscope");

app.Run();
