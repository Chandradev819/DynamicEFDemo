using DynamicEFDemo.Components;
using DynamicEFDemo.Helper;
using DynamicEFDemo.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<DynamicDbContextFactory>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
