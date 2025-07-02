using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Tutel.EduWork.Components;
using Tutel.EduWork.Components.Account;
using Tutel.EduWork.Data;
using Tutel.EduWork.DataAccessLayer;
using Tutel.EduWork.DataAccessLayer.Entities;
using Tutel.EduWork.Extensions;

namespace Tutel.EduWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents()
                .AddAuthenticationStateSerialization();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();


            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            #region SERVICES
            builder.Services.AddApplicationServices();
            #endregion

            #region REPOS
            builder.Services.AddRepositories();
            #endregion

            #region MAPPER
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            #region SEED
            builder.Services.AddTransient<DataSeeder>();
            #endregion

            #region MUD
            builder.Services.AddMudServices();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (!app.Environment.IsEnvironment("Containers"))
            {
                app.UseHttpsRedirection();
            }
            else
            {
                StaticWebAssetsLoader.UseStaticWebAssets(app.Environment, app.Configuration);
            }

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            using var scope = app.Services.CreateScope();

            #region MIGRATION

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            #endregion

            #region SEED
           
            var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            seeder.Seed();

            #endregion

            app.Run();
        }
    }
}
