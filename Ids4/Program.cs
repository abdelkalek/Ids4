
using Ids4;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddIdentityServer()
         .AddDeveloperSigningCredential()
         .AddOperationalStore(options =>
         {
             options.EnableTokenCleanup = true;
             options.TokenCleanupInterval = 30; // interval in seconds
         })
         .AddInMemoryApiResources(Config.GetApiResources())
         .AddInMemoryClients(Config.GetClients()).AddInMemoryApiScopes(Config.ApiScopes()).AddTestUsers(Config.GetUsers()).AddProfileService<ProfileService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseIdentityServer();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthorization();

app.MapRazorPages();

app.Run();
