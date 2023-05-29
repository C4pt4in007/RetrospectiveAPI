using RetrospectiveAPI.Service.AddFeedback;
using RetrospectiveAPI.Service.CreateRetrospective;
using RetrospectiveAPI.Service.GetAllRetrospectives;
using RetrospectiveAPI.Service.GetRetrospectivesByDate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICreateRetrospectiveService, CreateRetrospectiveService>();
builder.Services.AddScoped<IGetAllRetrospectivesService, GetAllRetrospectivesService>();
builder.Services.AddScoped<IGetRetrospectivesByDate, GetRetrospectivesByDateService>();
builder.Services.AddScoped<IAddFeedbackService, AddFeedbackService>();
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
