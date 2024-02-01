using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTDataHiveFrontend.Components;
using NTDataHiveFrontend.Components.Account;
using NTDataHiveFrontend.Data;
using NTDataHiveFrontend.ServiceAccess;
using Plugins.DataStore.InMemory.Dropdown;
using UseCases.Dropdown;
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

builder.Services.AddTransient<PersonBackendService>();
builder.Services.AddTransient<EvaluationBackendService>();

builder.Services.AddScoped<IPublisherRepository, PubisherInMemoryRepository>();
builder.Services.AddScoped<IJournalRepository, JournalInMemoryRepository>();
builder.Services.AddScoped<IErrorTypeRepository, ErrorTypeInMemoryRepository>();
builder.Services.AddScoped<IErrorLocationRepository, ErrorLocationInMemoryRepository>();
builder.Services.AddScoped<IQualityAssuranceRepository, QualityAssuranceInMemoryRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentInMemoryRepository>();
builder.Services.AddScoped<IAccountRepository, AccountInMemoryRepository>();
builder.Services.AddScoped<IPositionRepository, PositionInMemoryRepository>();
builder.Services.AddScoped<IComponentRepository, ComponentInMemoryRepository>();

builder.Services.AddScoped<IViewJournalIdByPublisherNameUseCase, ViewJournalIdByPublisherNameUseCase>();
builder.Services.AddScoped<IViewPublisherUseCase, ViewPublisherUseCase>();
builder.Services.AddScoped<IViewErrorTypeByErrorCodeNameUseCase, ViewErrorTypeByErrorCodeNameUseCase>();
builder.Services.AddScoped<IViewErrorLocationUseCase, ViewErrorLocationUseCase>();
builder.Services.AddScoped<IViewQualityAssuranceUseCase, ViewQualityAssuranceUseCase>();
builder.Services.AddScoped<IViewDepartmentUseCase, ViewDepartmentUseCase>();
builder.Services.AddScoped<IViewAccountUseCase, ViewAccountUseCase>();
builder.Services.AddScoped<IViewPositionUseCase, ViewPositionUseCase>();
builder.Services.AddScoped<IViewComponentUseCase, ViewComponentUseCase>();

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