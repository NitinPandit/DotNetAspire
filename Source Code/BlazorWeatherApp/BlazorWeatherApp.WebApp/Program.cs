using BlazorWeatherApp.WebApp.Components;
using BlazorWeatherApp.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("WeatherAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseAddress"]);
});
builder.Services.AddScoped<WeatherService>();

// Add Service Defaults to WebApp Project
builder.AddServiceDefaults();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add Default Endpoints coming from ServiceDefaults
app.MapDefaultEndpoints();

app.Run();
