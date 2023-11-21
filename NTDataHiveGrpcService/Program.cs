using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using NTDataHiveGrpcService.BLL.RecordInterfaces;
using NTDataHiveGrpcService.BLL.RecordRepository;
using NTDataHiveGrpcService.DAL.Data;
using NTDataHiveGrpcService.DAL.GAP.Persistence;
using NTDataHiveGrpcService.DAL.GAP.PersistenceInterfaces;
using NTDataHiveGrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddScoped<IEmployeeRecordPersistence, EmployeeRecordPersistence>();
builder.Services.AddScoped<IEmployeeRecordRepository, EmployeeRecordRepository>();

builder.Services.AddDbContext<PersonContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
});

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("cors", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<EmployeeService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
