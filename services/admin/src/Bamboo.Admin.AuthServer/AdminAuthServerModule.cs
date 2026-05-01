using System;
using System.IO;
using System.Linq;
using Localization.Resources.AbpUi;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging;

using StackExchange.Redis;
using OpenIddict.Server.AspNetCore;

using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.Security.Claims;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Account.Localization;

using Bamboo.Abp.LoginUi.Web;
using Bamboo.Admin.EntityFrameworkCore;
using Bamboo.Admin.Localization;
using Bamboo.Admin.MultiTenancy;
using OpenIddict.Server;
using Nethereum.Web3;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Admin;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AdminEntityFrameworkCoreModule),
    typeof(AbpLoginUiWebModule),
    typeof(AbpAspNetCoreSerilogModule)
    )]
public class AdminAuthServerModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        PreConfigure<OpenIddictBuilder>(builder =>
        {
            builder.AddValidation(options =>
            {
                options.AddAudiences("Bamboo", "Admin", "Core", "Web3");
                options.UseLocalServer();
                options.UseAspNetCore();
            });
        });

        // PreConfigure<OpenIddictServerBuilder>(builder =>
        // {
        //     builder.SetAuthorizationCodeLifetime(TimeSpan.FromHours(1));
        //     builder.SetAccessTokenLifetime(TimeSpan.FromDays(30));
        //     var issuer = configuration["AuthServer:Authority"];
        //     if (!string.IsNullOrWhiteSpace(issuer))
        //     {
        //         builder.SetIssuer(new Uri(issuer));
        //     }

        //     builder.AllowCustomFlow("switch_tenant");
        //     builder.AddEventHandler<OpenIddictServerEvents.HandleTokenRequestContext>(options =>
        //         options.UseScopedHandler<SwitchTenantTokenExtensionGrant>());
        // });

        PreConfigure<OpenIddictServerAspNetCoreBuilder>(configure =>
        {
            configure.DisableTransportSecurityRequirement();
        });
        if (!hostingEnvironment.IsDevelopment())
        {
            PreConfigure<AbpOpenIddictAspNetCoreOptions>(options =>
            {
                options.AddDevelopmentEncryptionAndSigningCertificate = false;
            });

            PreConfigure<OpenIddictServerBuilder>(serverBuilder =>
            {
                // Optional: Use custome openiddict.pfx
                string pfxKey = configuration["AuthServer:PfxKey"] ?? "9d763224-f649-47fc-a509-c5ab6aef4008";
                serverBuilder.AddProductionEncryptionAndSigningCertificate("openiddict.pfx", pfxKey);
                //serverBuilder.AddProductionEncryptionAndSigningCertificate("openiddict.pfx", "9d763224-f649-47fc-a509-c5ab6aef4008");
            });
        }
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(AdminAuthServerModule).Assembly);
        });

        Configure<OpenIddictServerAspNetCoreOptions>(options =>
        {
            options.DisableTransportSecurityRequirement = true;
        });

        Configure<AbpOpenIddictAspNetCoreOptions>(options =>
        {
            options.AddDevelopmentEncryptionAndSigningCertificate = true;
            // Ngăn OpenIddict dùng Request.Scheme + Host
            // options.DisableAccessTokenIssuer = true;
        });

        Configure<OpenIddictServerBuilder>(builder =>
        {
            // Ép buộc Issuer từ appsettings.json
            var issuer = configuration["AuthServer:Authority"];
            if (!string.IsNullOrWhiteSpace(issuer))
            {
                builder.SetIssuer(new Uri(issuer));
            }
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AdminResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource),
                    typeof(AccountResource)
                );
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                LeptonXLiteThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-styles.css");
                }
            );
        });

        Configure<AbpAuditingOptions>(options =>
        {
            //options.IsEnabledForGetRequests = true;
            options.ApplicationName = "AuthServer";
        });

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<AdminDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Bamboo.Admin.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<AdminDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Bamboo.Admin.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<AbpLoginUiWebModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Bamboo.LoginUi.Web"));
            });
        }

        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"]?.Split(',') ?? Array.Empty<string>());

            options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
            options.Applications["Angular"].Urls[AccountUrlNames.PasswordReset] = "account/reset-password";
        });

        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "Bamboo:";
        });

        ConfigureRedis(context, configuration);
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureDistributedLocking(context, configuration);

        //var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("Admin");
        //if (!hostingEnvironment.IsDevelopment())
        //{
        //    var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
        //    bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
        //    redisOptions.User = configuration["Redis:User"];
        //    redisOptions.Password = configuration["Redis:Password"];
        //    var redis = ConnectionMultiplexer.Connect(redisOptions);

        //    dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "Admin-Protection-Keys");
        //}

        //context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        //{
        //    var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
        //    bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
        //    redisOptions.User = configuration["Redis:User"];
        //    redisOptions.Password = configuration["Redis:Password"];
        //    var connection = ConnectionMultiplexer.Connect(redisOptions);
        //    //var connection = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
        //    return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        //});

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    //.SetIsOriginAllowed(_ => true)
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        context.Services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            // Tắt tính năng tự động check DB mỗi request
            options.IsDynamicClaimsEnabled = true;
        });
    }

    private void ConfigureRedis(ServiceConfigurationContext context, IConfiguration configuration)
    {
        //var hostingEnvironment = context.Services.GetHostingEnvironment();

        var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
        bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);

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
    }

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("Bamboo");
        string appName = configuration["App:Name"] ?? "Bamboo";
        var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
        bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
        if (enabledRedis)
        {
            redisOptions.User = configuration["Redis:User"];
            redisOptions.Password = configuration["Redis:Password"];
            var redis = ConnectionMultiplexer.Connect(redisOptions);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, $"{appName}-Protection-Keys");
            return;
        }
        //if (!hostingEnvironment.IsDevelopment())
        //{
        //    var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
        //    dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "Bamboo-Protection-Keys");
        //}
    }

    private void ConfigureDistributedLocking(
        ServiceConfigurationContext context,
        IConfiguration configuration)
    {
        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
            bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
            if (!enabledRedis)
            {
                //DirectoryInfo lockFileDirectory = new DirectoryInfo($".bamboocache");
                //return new FileDistributedSynchronizationProvider(lockFileDirectory);
            }
            else
            {
                redisOptions.User = configuration["Redis:User"];
                redisOptions.Password = configuration["Redis:Password"];
                var redis = ConnectionMultiplexer.Connect(redisOptions);
                return new RedisDistributedSynchronizationProvider(redis.GetDatabase());
            }
            var connection = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
    }



    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
        var logHeaders = configuration.GetValue<bool>("Logging:RequestLogging:LogHeaders");
        var useSSL = configuration.GetValue("Auth:OpenIddict:UseSSL", true);
        var useSubpath = configuration.GetValue("App:EnableSubpath", true);
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.All
        });
        if (logHeaders)
        {
            // Lấy logger từ LoggerFactory (không phụ thuộc vào Program)
            var loggerFactory = context.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<AdminAuthServerModule>();

            app.Use(async (ctx, next) =>
            {
                logger.LogInformation("===== Incoming Request ===== ");
                logger.LogInformation("{Method} {Scheme}://{Host}{Path}{QueryString}",
                    ctx.Request.Method,
                    ctx.Request.Scheme,
                    ctx.Request.Host,
                    ctx.Request.Path,
                    ctx.Request.QueryString);

                foreach (var header in ctx.Request.Headers)
                {
                    logger.LogInformation("Header: {Key} = {Value}", header.Key, header.Value.ToString());
                }

                logger.LogInformation("============================");

                await next();
            });
        }
        if (useSubpath)
        {
            app.UsePathBase("/admin");
        }
        ///// Always behind ssl proxy
        if (useSSL)
        {
            app.Use((context, next) =>
            {
                var xproto = context.Request.Headers["X-Forwarded-Proto"].ToString();
                if (xproto != null && xproto.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    context.Request.Scheme = "https";
                }
                // force https
                context.Request.Scheme = "https";
                return next();
            });
        }

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        //app.UseStaticFiles();
        app.MapAbpStaticAssets();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
