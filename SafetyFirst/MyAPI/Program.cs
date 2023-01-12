using MyAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddJWT();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// I'll take advantage of session state in this example to store the generated token
app.UseSession();
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("token");

    if (!String.IsNullOrEmpty(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);

    await next();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
