using BlazorApp10.Components;
using Microsoft.EntityFrameworkCore;
using BlazorApp10.Data;
using BlazorApp10.Interfaces.Services;
using BlazorApp10.Models;
using BlazorApp10.Services;
using BlazorApp10.Interfaces.Repositories;
using BlazorApp10.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookDbContext>
    (options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookService, BookService>();
//Repository
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
