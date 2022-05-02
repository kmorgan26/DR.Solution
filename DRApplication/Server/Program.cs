global using System.Linq.Expressions;
global using System.Reflection;
global using Microsoft.EntityFrameworkCore;

using DRApplication.Server;


var app = WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build();

app.SetupMiddleware().Run();