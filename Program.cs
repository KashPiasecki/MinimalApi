// Builder
var builder = WebApplication.CreateBuilder(args);
//Services
// builder.Services.AddEndpointsApiExplorer();
//App 
var app = builder.Build();
app.UseHttpsRedirection();
app.Run();