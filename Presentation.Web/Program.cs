using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Hosting.Builder;
using Presentation.Web.Components;
using Presentation.Web.Models.DTOs;
using Presentation.Web.Services;

var builder = WebApplication.CreateBuilder(args);
var url = "https://localhost:44328/";
// Add services to the container.

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient<ITurmaService, TurmaService>(client =>
{
    client.BaseAddress = new Uri(url);
});
builder.Services.AddHttpClient<IAlunoService, AlunoService>(client =>
{
        client.BaseAddress = new Uri(url);
});
builder.Services.AddHttpClient<IAluno_TurmaService, Aluno_TurmaService>(client =>
{
    client.BaseAddress = new Uri(url);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapBlazorHub();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
