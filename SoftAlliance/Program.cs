using SoftAlliance.Utilities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureBaseServices();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.ConfigureEndPoints();
app.Run();