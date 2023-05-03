using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Extensions.DependencyInjection;

using OpenIddict.Validation.AspNetCore;

using Medallion.Threading;
using Medallion.Threading.Redis;
using Medallion.Threading.FileSystem;
using StackExchange.Redis;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Twilio;

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

using Bamboo.Abp.LoginUi.Web.Localization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Bamboo.Abp.VerificationCode;

namespace Bamboo.Abp.LoginUi.Web;
[DependsOn(
    typeof(AbpAccountWebModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule)
)]
public class AbpLoginUiWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
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
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        context.Services.AddHttpClient();
        context.Services.TryAddTransient<IVerificationCodeGenerator, VerificationCodeGenerator>();
        context.Services.TryAddTransient<IVerificationCodeManager, VerificationCodeManager>();
        //ConfigureFirebase(context, configuration);
        //ConfigureTwilio(context, configuration);

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

        // context.Services.AddSameSiteCookiePolicy();
        ConfigureAuthentication(context, configuration);
        ConfigureTenantResolver(context, configuration);
        ConfigureCache(context, configuration);
        ConfigureRedis(context, configuration);
        ConfigureDistributedLock(context, configuration);
        ConfigureDataProtection(context, configuration);
        ConfigureForwardProxy(context, configuration);

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
        context.Services.AddAuthentication()
            .AddFacebook(options =>
            {
                options.AppId = configuration["Authentication:Facebook:AppId"];
                options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                options.Scope.Add("email");
                options.Scope.Add("public_profile");
                options.SaveTokens = true;
                // sigin-facebook
            })
            .AddGoogle(options =>
            {
                options.ClientId = configuration["Authentication:Google:ClientId"];
                options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                //options.Scope.Add("email");
                //options.Scope.Add("openid");
            })
            //.AddMicrosoftAccount(options =>
            //{
            //    options.ClientId = "8208d98e-400d-4ce9-89ba-d92610c67e13";
            //    options.ClientSecret = "hsrMP46|_kfkcYCWSW516?%";
            //})
            //.AddDefaultSocial(configuration)
            ;
    }

    // Disable select tenant when login
    private void ConfigureTenantResolver(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.Configure<AbpAspNetCoreMultiTenancyOptions>(options =>
        {
            options.TenantKey = configuration["App:TenantKey"] ?? "tenant";
        });

        Configure<AbpTenantResolveOptions>(options =>
        {
            options.TenantResolvers.Clear();
            options.TenantResolvers.Add(new CurrentUserTenantResolveContributor());
        });
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
            options.KnownNetworks.Clear();
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
        GlobalSettingManagementProvider settingManagementProvider = context.ServiceProvider.GetRequiredService<GlobalSettingManagementProvider>();
        SettingDefinitionManager settingDefinitionManager = context.ServiceProvider.GetRequiredService<SettingDefinitionManager>();
        await settingManagementProvider.SetAsync(
           settingDefinitionManager.Get(AccountSettingNames.IsSelfRegistrationEnabled),
           true.ToString(),
           GlobalSettingValueProvider.ProviderName
        );

        //settingManagementProvider.SetAsync(
        //    settingDefinitionManager.Get(IdentitySettingNames.Password.RequireNonAlphanumeric),
        //    false.ToString(),
        //    GlobalSettingValueProvider.ProviderName
        //);

        //settingManagementProvider.SetAsync(
        //    settingDefinitionManager.Get(IdentitySettingNames.Password.RequireUppercase),
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
}
