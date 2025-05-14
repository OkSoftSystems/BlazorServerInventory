using Application.DependencyInjection;
using Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using NetcodeHub.Packages.Components.DataGrid;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using WebUI.Components;
using WebUI.Components.Layout.Identity;
using WebUI.Hubs;
using WebUI.States;
using WebUI.States.Administration;
using WebUI.States.User;

var builder = WebApplication.CreateBuilder(args);

// Add service containers.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();


builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthStateProvider>();
builder.Services.AddScoped<ChangePasswordState>();
builder.Services.AddScoped<UserActiveOrderCountState>();
builder.Services.AddScoped<AdminActiveOrderCountState>();
builder.Services.AddScoped<GenericHomeHeaderState>();
builder.Services.AddScoped<NetcodeHubConnectionService>();   
builder.Services.AddScoped<ICustomAuthorizationService, CustomAuthorizationService>();
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzc5NzgxNUAzMjM4MmUzMDJlMzBFNkdXbVZRWUhXTXZ1bzhWckR1Vm8zUkVEbXhqcnF2Z0d4MDZGZ05TdWw0PQ==");
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddMudServices();
builder.Services.AddSignalR();
builder.Services.AddVirtualizationService();


//builder.Logging.SetMinimumLevel(LogLevel.Debug);

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
app.MapSignOutEnpoint();
app.MapHub<CommunicationHub>("/communicationhub");
app.Run();
