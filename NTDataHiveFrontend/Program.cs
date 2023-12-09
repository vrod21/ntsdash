using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTDataHiveFrontend.Components;
using NTDataHiveFrontend.Components.Account;
using NTDataHiveFrontend.Data;
using NTDataHiveFrontend.ServiceAccess;
using Plugins.DataStore.InMemory.Dropdown;
using UseCases.Dropdown.DataStorePluginInterfaces;
using UseCases.Dropdown.DropdownUseCase;
using UseCases.Dropdown.UseCaseInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("connectionString") ?? throw new InvalidOperationException("Connection string 'connectionString' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddTransient<EmployeeBackendService>();
builder.Services.AddTransient<PreEditingFeedbackBackendService>();
builder.Services.AddTransient<RevisionBackendService>();
builder.Services.AddTransient<PersonNotExistBackendService>();
builder.Services.AddTransient<DropdownBackendService>();



builder.Services.AddScoped<IPublisherRepository, PublisherInMemoryRepository>();
builder.Services.AddScoped<IJournalRepository, JournalInMemoryRepository>();



builder.Services.AddTransient<IViewPublisherUseCase, ViewPublisherUseCase>();
builder.Services.AddTransient<IViewJournalUseCase, ViewJournalUseCase>();



builder.Services.AddScoped<Radzen.DialogService>();

builder.Services.AddSingleton<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();