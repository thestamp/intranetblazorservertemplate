using IntranetServerTemplate.Core.Data;
using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.ExternalConnectors;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

//Entity Framework - https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings#aspnet-core
builder.Services.AddDbContextFactory<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("IntranetServerTemplateDataContext"), //get connection string
    x => x.MigrationsAssembly("IntranetServerTemplate.Core")) //point the migrations engine to IntranetServerTemplate.Core 
    );

builder.Services.AddAuthorization(options =>
{
    //Azure AD Authorization
    options.AddPolicy("FetchDataPolicy", policy =>
        policy.RequireRole("FetchData.Access"));
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<DataContext>(); //todo CONFIRM NO ISSUES with using AddTransient<DataContext>() with blazor server -
//                                              //transient makes it so that the dbcontext in one component does not change the data models on other components.
//                                              //Scoped shares the same dbcontext across the user's session (we don't want this)
//                                              //https://docs.microsoft.com/en-us/aspnet/core/blazor/blazor-server-ef-core?view=aspnetcore-6.0#database-access

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
