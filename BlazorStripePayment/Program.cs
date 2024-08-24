using BlazorStripePayment.Components;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    // Stored using dotnet user-secrets 
    // dotnet user-secrets init
    // dotnet user-secrets set "Stripe:TestApiKey" "API-KEY"
    StripeConfiguration.ApiKey = builder.Configuration["Stripe:TestApiKey"]; 
}



app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
