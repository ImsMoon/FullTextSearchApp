using SearchModule.Contacts;
using SearchModule.Data;
using SearchModule.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISqlHandler,SqlHandler>
(_ => new SqlHandler(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISearchRepository,SearchRepository>();
builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json","Search App");
    });
}
app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowCredentials()
    .SetIsOriginAllowed(hostName => true));
app.MapControllers();

app.Run();
