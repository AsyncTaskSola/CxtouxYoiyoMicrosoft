using SkyApm.Utilities.DependencyInjection;
using SkyWalkingExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSkyApmExtensions();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region consul≈‰÷√
var res = new ConsulOption
{
    ServiceName = app.Configuration["ServiceName"],
    ServiceIp = app.Configuration["ServiceIP"],
    ServicePort = Convert.ToInt32(app.Configuration["ServicePort"]),
    ServiceHealthCheck = app.Configuration["ServiceHealthCheck"],
    Address = app.Configuration["ConsulAddress"],
};
app.RegisterConsul(app.Lifetime, res);

#endregion



app.UseAuthorization();

app.MapControllers();

app.Run();
