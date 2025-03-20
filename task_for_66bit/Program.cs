using task_for_66bit.Data;
using task_for_66bit.Data.Repositories;
using task_for_66bit.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<InternRepository>();
builder.Services.AddScoped<DirectionRepository>();
builder.Services.AddScoped<ProjectRepository>();

builder.Services.AddScoped<InternService>();
builder.Services.AddScoped<DirectionService>();
builder.Services.AddScoped<ProjectService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();