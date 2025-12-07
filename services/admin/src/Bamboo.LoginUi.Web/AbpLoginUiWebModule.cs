using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


using OpenIddict.Validation.AspNetCore;

using Medallion.Threading;
using Medallion.Threading.Redis;
using Medallion.Threading.FileSystem;
using StackExchange.Redis;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Twilio;
using OpenIddict.Server;

using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.Account.Localization;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Settings;
using Volo.Abp.Identity.Settings;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Account.Web.ProfileManagement;


using Bamboo.Abp.LoginUi.Web.Localization;
using Bamboo.Abp.VerificationCode;
using Bamboo.Abp.LoginUi.Services;
using Bamboo.OpenIddictExtensions;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;
using Bamboo.Abp.LoginUi.Web.Menus;
using Bamboo.Abp.LoginUi.Web.ProfileManagement;

namespace Bamboo.Abp.LoginUi.Web;

[DependsOn(
    typeof(AbpAccountWebModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule)
)]
public class AbpLoginUiWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(AbpLoginUiResource), typeof(AbpLoginUiWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpLoginUiWebModule).Assembly);
        });

        PreConfigure<OpenIddictServerBuilder>(builder =>
        {
            builder.UseAspNetCore().DisableTransportSecurityRequirement();
        });
        PreConfigure<OpenIddictServerBuilder>(builder =>
        {
            builder.SetAuthorizationCodeLifetime(TimeSpan.FromHours(1));
            builder.SetAccessTokenLifetime(TimeSpan.FromDays(30));
            var issuer = configuration["AuthServer:Authority"];
            if (!string.IsNullOrWhiteSpace(issuer))
            {
                builder.SetIssuer(new Uri(issuer));
            }

            builder.AllowCustomFlow("switch_tenant");
            builder.AddEventHandler<OpenIddictServerEvents.HandleTokenRequestContext>(options =>
                options.UseScopedHandler<SwitchTenantTokenExtensionGrant>());
        });
        // PreConfigure<AbpOpenIddictAspNetCoreOptions>(options =>
        // {
        //     options.AddDevelopmentEncryptionAndSigningCertificate = false;
        // });
        // PreConfigure<OpenIddictServerAspNetCoreBuilder>(configure =>
        // {
        //     configure.DisableTransportSecurityRequirement();
        // });
        // PreConfigure<OpenIddictServerBuilder>(serverBuilder =>
        // {
        //     // Optional: Use custome openiddict.pfx
        //     string pfxKey = configuration["AuthServer:PfxKey"] ?? "9d763224-f649-47fc-a509-c5ab6aef4008";
        //     serverBuilder.AddProductionEncryptionAndSigningCertificate("openiddict.pfx", pfxKey);
        //     //serverBuilder.AddProductionEncryptionAndSigningCertificate("openiddict.pfx", "9d763224-f649-47fc-a509-c5ab6aef4008");
        // });

    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        context.Services.AddMemoryCache();
        context.Services.AddHttpClient();

        context.Services.AddTransient<IWeb3AuthService, Web3AuthService>();
        context.Services.TryAddTransient<IVerificationCodeGenerator, VerificationCodeGenerator>();
        context.Services.TryAddTransient<IVerificationCodeManager, VerificationCodeManager>();
        //ConfigureFirebase(context, configuration);
        //ConfigureTwilio(context, configuration);

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(AbpLoginUiWebModule).Assembly);
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpLoginUiWebModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpLoginUiResource>("en")
                .AddBaseTypes(typeof(AccountResource))
                .AddVirtualJson("/Localization/Bamboo/Abp/LoginUi");
        });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });

        Configure<RazorPagesOptions>(options =>
        {
            // Cho phép truy cập ẩn danh vào trang cụ thể này
            options.Conventions.AllowAnonymousToPage("/Account/SiWXSignIn");
        });
        // context.Services.AddSameSiteCookiePolicy();
        ConfigureAuthentication(context, configuration);
        ConfigureTenantResolver(context, configuration);
        ConfigureCache(context, configuration);
        ConfigureRedis(context, configuration);
        ConfigureDistributedLock(context, configuration);
        ConfigureDataProtection(context, configuration);
        ConfigureForwardProxy(context, configuration);
        //services.AddHostedService<TelegramBotHostedService>();

        // Configure<AbpAutoMapperOptions>(options =>
        //         {
        //             options.AddMaps<AdminWebModule>();
        //         });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AdminWebMenuContributor());
        });
    }

    private void ConfigureFirebase(ServiceConfigurationContext context, IConfiguration configuration)
    {
        FirebaseApp.Create(new AppOptions()
        {
            //export GOOGLE_APPLICATION_CREDENTIALS
            //Credential = GoogleCredential.GetApplicationDefault(),
            Credential = GoogleCredential.FromFile("firebase-adminsdk.json"),
        }); ;
    }

    private void ConfigureTwilio(ServiceConfigurationContext context, IConfiguration configuration)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        string accountSid = configuration["Twilio:AccountSID"];
        string authToken = configuration["Twilio:AuthToken"];
        TwilioClient.Init(accountSid, authToken);
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        //context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(options =>
        //    {
        //        options.Authority = configuration["AuthServer:Authority"];
        //        options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
        //        options.Audience = "Admin";
        //    });

        context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/?view=aspnetcore-6.0&tabs=visual-studio
        //var builder = context.Services.AddAuthentication();
        var builder = context.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        });
        ConfigureDefaultSocialAuthentication(builder, configuration);
    }

    // Disable select tenant when login
    private void ConfigureTenantResolver(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.Configure<AbpAspNetCoreMultiTenancyOptions>(options =>
        {
            options.TenantKey = configuration["App:TenantKey"] ?? "tenant";
        });

        //bool enabledTenantLogin = Convert.ToBoolean(configuration["App:EnableTenantLogin"]);
        bool enabledTenantLogin = configuration.GetValue("App:EnableTenantLogin", true);
        if (!enabledTenantLogin)
        {
            Configure<AbpTenantResolveOptions>(options =>
            {
                options.TenantResolvers.Clear();
                options.TenantResolvers.Add(new CurrentUserTenantResolveContributor());
            });
        }
    }

    private void ConfigureCache(ServiceConfigurationContext context, IConfiguration configuration)
    {
        //Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "Admin:"; });
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = configuration["App:CacheName"] ?? "Bamboo:"; });

    }

    private void ConfigureRedis(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
        var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);

        if (enabledRedis)
        {
            redisOptions.User = configuration["Redis:User"];
            redisOptions.Password = configuration["Redis:Password"];
            Configure<RedisCacheOptions>(options =>
            {
                //var configurationOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
                //configurationOptions.User = configuration["Redis:User"];
                //configurationOptions.Password = configuration["Redis:Password"];
                //options.ConfigurationOptions = configurationOptions;
                options.Configuration = configuration["Redis:Configuration"];
                options.ConfigurationOptions = redisOptions;
            });
        }

        //if (!hostingEnvironment.IsDevelopment())
        //if (enabledRedis)
        //{
        //    var redis = ConnectionMultiplexer.Connect(redisOptions);
        //    //var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        //    var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("Bamboo");
        //    dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "Bamboo-Protection-Keys");
        //}

        //context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        //{
        //    //if (hostingEnvironment.IsDevelopment())
        //    if (!enabledRedis)
        //    {
        //        DirectoryInfo lockFileDirectory = new DirectoryInfo($".bamboocache");
        //        return new FileDistributedSynchronizationProvider(lockFileDirectory);
        //    }
        //    else
        //    {
        //        //var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
        //        //redisOptions.User = configuration["Redis:User"];
        //        //redisOptions.Password = configuration["Redis:Password"];
        //        //var connection = ConnectionMultiplexer
        //        //    .Connect(configuration["Redis:Configuration"]);

        //        var connection = ConnectionMultiplexer
        //            .Connect(redisOptions);
        //        return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        //    }
        //});
    }

    private void ConfigureDistributedLock(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
            bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
            if (!enabledRedis)
            {
                DirectoryInfo lockFileDirectory = new DirectoryInfo($".bamboocache");
                return new FileDistributedSynchronizationProvider(lockFileDirectory);
            }
            else
            {
                redisOptions.User = configuration["Redis:User"];
                redisOptions.Password = configuration["Redis:Password"];
                var redis = ConnectionMultiplexer.Connect(redisOptions);
                return new RedisDistributedSynchronizationProvider(redis.GetDatabase());
            }
        });
    }

    private void ConfigureDataProtection(ServiceConfigurationContext context, IConfiguration configuration)
    {
        string appName = configuration["App:Name"] ?? "Bamboo";
        //string appName = configuration["ApplicationName"] ?? "Bamboo";
        //string appName = context.Services.GetApplicationName();
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName($"{appName}");
        //var hostingEnvironment = context.Services.GetHostingEnvironment();
        //if (!hostingEnvironment.IsDevelopment())
        {
            var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
            bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
            if (enabledRedis)
            {
                redisOptions.User = configuration["Redis:User"];
                redisOptions.Password = configuration["Redis:Password"];
                var redis = ConnectionMultiplexer.Connect(redisOptions);
                dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, $"{appName}-Protection-Keys");
            }
        }
    }

    private void ConfigureForwardProxy(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
                                       | ForwardedHeaders.XForwardedProto
                                       | ForwardedHeaders.XForwardedHost;
            options.KnownIPNetworks.Clear();
            //options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
            options.RequireHeaderSymmetry = false;
        });

        context.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.RequestHeaders
                                    //| HttpLoggingFields.RequestPropertiesAndHeaders 
                                    //| HttpLoggingFields.ResponsePropertiesAndHeaders
                                    //| HttpLoggingFields.ResponseHeaders
                                    //| HttpLoggingFields.RequestProtocol
                                    //| HttpLoggingFields.ResponseBody
                                    //| HttpLoggingFields.RequestBody
                                    | HttpLoggingFields.RequestPath;

        });
    }

    public async override Task OnApplicationInitializationAsync(Volo.Abp.ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        //GlobalSettingManagementProvider settingManagementProvider = context.ServiceProvider.GetRequiredService<GlobalSettingManagementProvider>();
        //SettingDefinitionManager settingDefinitionManager = context.ServiceProvider.GetRequiredService<SettingDefinitionManager>();
        //await settingManagementProvider.SetAsync(
        //   await settingDefinitionManager.GetAsync(AccountSettingNames.IsSelfRegistrationEnabled),
        //   true.ToString(),
        //   GlobalSettingValueProvider.ProviderName
        //);

        //await settingManagementProvider.SetAsync(
        //    await settingDefinitionManager.GetAsync(IdentitySettingNames.Password.RequireNonAlphanumeric),
        //    false.ToString(),
        //    GlobalSettingValueProvider.ProviderName
        //);

        //await settingManagementProvider.SetAsync(
        //    await settingDefinitionManager.GetAsync(IdentitySettingNames.Password.RequireUppercase),
        //    false.ToString(),
        //    GlobalSettingValueProvider.ProviderName
        //);

        //app.UseHttpMethodOverride();
        app.UseForwardedHeaders();
        //app.UseHttpLogging();

        ///// Always behind ssl proxy
        app.Use((context, next) =>
        {
            var xproto = context.Request.Headers["X-Forwarded-Proto"].ToString();
            if (xproto != null && xproto.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                context.Request.Scheme = "https";
            }
            return next();
        });

        await base.OnApplicationInitializationAsync(context);
    }

    private void ConfigureDefaultSocialAuthentication(AuthenticationBuilder builder, IConfiguration configuration)
    {
        var section = configuration.GetSection("Authentication:Google");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            var clientId = section["ClientId"];
            var clientSecret = section["ClientSecret"];
            builder.AddGoogle(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
            });
        }
        section = configuration.GetSection("Authentication:Microsoft");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddMicrosoftAccount(options =>
            {
                options.ClientId = section["ClientId"] ?? "8208d98e-400d-4ce9-89ba-d92610c67e13";
                options.ClientSecret = section["ClientSecret"] ?? "hsrMP46|_kfkcYCWSW516?%";
            });
        }
        section = configuration.GetSection("Authentication:Twitter");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddTwitter(options =>
            {
                options.ConsumerKey = section["ClientId"];
                options.ConsumerSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Apple");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddApple(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Facebook");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddFacebook(options =>
            {
                options.AppId = section["AppId"];
                options.AppSecret = section["AppSecret"];
                options.Scope.Add("email");
                options.Scope.Add("public_profile");
            });
        }
        section = configuration.GetSection("Authentication:Instagram");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddInstagram(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Line");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            var str = section["ClientId"];
            builder.AddLine(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:LinkedIn");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddLinkedIn(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Keycloak");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddKeycloak(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
                options.AuthorizationEndpoint = section["AuthorizationEndpoint"];
                options.TokenEndpoint = section["TokenEndpoint"];
                options.UserInformationEndpoint = section["UserInformationEndpoint"];
            });
        }
        section = configuration.GetSection("Authentication:Zalo");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddZalo(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
    }
}
