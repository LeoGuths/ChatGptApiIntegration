using ChatGpt.ApiIntegration.Extensions;

const string appName = "ChatGPT Web Integration";
const string version = "v1";
    
var builder = WebApplication.CreateBuilder(args);
builder.AddChatGpt();
builder.AddSerilog();

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddSwagger(appName, version);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc(appName, version);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();