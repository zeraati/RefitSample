using Refit;
using RefitSample.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRefitClient<IJsonPlaceHolder>()
    .ConfigureHttpClient(config => config.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
