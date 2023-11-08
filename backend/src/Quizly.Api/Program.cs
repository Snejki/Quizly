using Quizly.Shared.Infrastructure;
using Quizly.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
var assemblies = ModulesLoader.LoadAssemblies(builder.Configuration);
var modules = ModulesLoader.LoadModules(assemblies);

builder.AddModularInfrastructure(builder.Configuration, assemblies, modules);
var app = builder.Build();
app.UseModularInfrastructure(assemblies, modules);

app.Run();