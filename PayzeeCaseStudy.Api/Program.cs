using PayzeeCaseStudy.KPSPublic;
using PayzeeCaseStudy.KPSPublic.Abstract;
using PayzeeCaseStudy.KPSPublic.Concreate;
using PayzeeCaseStudy.LoginService.Abstract;
using PayzeeCaseStudy.LoginService.Concreate;
using PayzeeCaseStudy.LoginService.DTO;
using PayzeeCaseStudy.NoneSecurePayService.Apstract;
using PayzeeCaseStudy.NoneSecurePayService.Concreate;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(x => new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap));
builder.Services.AddSingleton<IIdentificationService, IdentificationService>();

builder.Services.Configure<LoginRequest>(builder.Configuration.GetSection("PayzeeLoginParams"));
builder.Services.AddTransient<ILoginService, LoginService>();

builder.Services.AddHttpClient("PayzeeLoginService", client =>
{
    client.BaseAddress = new Uri($"https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/");
    client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
    client.Timeout = TimeSpan.FromMinutes(5);
});

builder.Services.AddTransient<INonesecurePayService, NonesecurePayService>();
builder.Services.AddHttpClient("PayzeeNonesecurePaymentService", client =>
{
    client.BaseAddress = new Uri($"https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/");
    client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
    client.Timeout = TimeSpan.FromMinutes(5);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
