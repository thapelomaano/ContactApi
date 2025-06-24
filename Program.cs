using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://thapelocontact.azurewebsites.net") 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();          

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=contacts.db"));

var app = builder.Build();

// Enable Swagger middleware
/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
/*}*/

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}
app.Run();
