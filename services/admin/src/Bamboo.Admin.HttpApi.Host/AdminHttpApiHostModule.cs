using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens.Jwt;

using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


using StackExchange.Redis;

using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.MultiTenancy;

using Bamboo.Admin.EntityFrameworkCore;
using Bamboo.Admin.MultiTenancy;
using Bamboo.AdminExtensions;
using System.Text.Json;

// using OpenIddict.Validation;
// using OpenIddict.Validation.AspNetCore;


namespace Bamboo.Admin;

[DependsOn(
    typeof(AdminHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AdminApplicationModule),
    typeof(AdminEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAdminExtensionsModule),
    typeof(AbpSwashbuckleModule)
)]
public class AdminHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        // PreConfigure<OpenIddictBuilder>(builder =>
        // {
        //     builder.AddValidation(options =>
        //     {
        //         options.AddAudiences("Bamboo");
        //         options.UseLocalServer();
        //         options.UseAspNetCore();
        //     });
        // });
    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        // Configure<AbpAuditingOptions>(options =>
        // {
        //     options.IsEnabled = false; // Tắt toàn bộ Audit Logging
        // });

        Configure<AbpAntiForgeryOptions>(options =>
        {
            options.AutoValidate = false; // Tắt toàn bộ antiforgery cho API
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.UserSharingStrategy = TenantUserSharingStrategy.Shared;
        });

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            // options.ConventionalControllers.Create(typeof(AdminHttpApiHostModule).Assembly, opts =>
            // {
            //     opts.RootPath = "admin";
            // });
        });
        ConfigureConventionalControllers();
        ConfigureAuthentication(context, configuration);
        ConfigureRedis(context, configuration);
        ConfigureCache(configuration);
        ConfigureVirtualFileSystem(context);
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureDistributedLocking(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
    }

    private void ConfigureCache(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "Bamboo:"; });
    }

    private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<AdminDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Bamboo.Admin.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<AdminDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Bamboo.Admin.Domain"));
                options.FileSets.ReplaceEmbeddedByPhysical<AdminApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Bamboo.Admin.Application.Contracts"));
                options.FileSets.ReplaceEmbeddedByPhysical<AdminApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}Bamboo.Admin.Application"));
            });
        }
    }

    private void ConfigureConventionalControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            //options.ConventionalControllers.Create(typeof(AdminApplicationModule).Assembly);
        });
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                var MetadataAddress = configuration["AuthServer:MetadataAddress"];
                if (!string.IsNullOrEmpty(MetadataAddress))
                {
                    options.MetadataAddress = MetadataAddress;
                }
                options.RequireHttpsMetadata = configuration.GetValue<bool>("AuthServer:RequireHttpsMetadata");
                options.Audience = "Bamboo";
                options.BackchannelHttpHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };
                // options.Events = new JwtBearerEvents
                // {
                //     OnAuthenticationFailed = context =>
                //     {
                //         Console.WriteLine("Auth failed: " + context.Exception.Message);
                //         return Task.CompletedTask;
                //     },
                //     OnTokenValidated = context =>
                //     {
                //         Console.WriteLine("Token validated");
                //         return Task.CompletedTask;
                //     }
                // };
                // options.TokenValidationParameters.ValidIssuers =
                // [
                //     "https://dad.vn",
                //     "https://dad.vn/",
                //     "https://localhost:44301",
                //     "https://localhost:44301/"
                //     //configuration["AuthServer:Authority"]?.TrimEnd('/'),
                //     //configuration["AuthServer:Authority"]?.TrimEnd('/') + "/"
                // ];
            });
        // .AddAbpJwtBearer("SelfSignedJwt", options =>
        // {
        //     var issuer = configuration["Auth:Jwt:Issuer"];
        //     var secretKey = configuration["Auth:Jwt:SecurityKey"];

        //     if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(secretKey))
        //     {
        //         throw new UserFriendlyException("Invalid Auth:Jwt:Issuer or Auth:Jwt:SecurityKey in appsettings.json");
        //     }
        //     options.TokenValidationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuer = true,
        //         ValidateAudience = false,
        //         ValidateLifetime = true,
        //         ValidateIssuerSigningKey = true,
        //         ValidIssuer = issuer,
        //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //     };
        // })
        //     .AddAbpJwtBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme, options =>
        //     {
        //         string pfxKey = configuration["AuthServer:PfxKey"] ?? "9d763224-f649-47fc-a509-c5ab6aef4008";
        //         //var cert = new X509Certificate2("openiddict.pfx", pfxPassword);

        //         options.Authority = configuration["AuthServer:Authority"];
        //         options.RequireHttpsMetadata = configuration.GetValue<bool>("AuthServer:RequireHttpsMetadata");
        //         options.Audience = "Bamboo";

        //         var introspection = configuration["AuthServer:IntrospectionEndpoint"];
        //         //if (!string.IsNullOrEmpty(introspection))
        //         {
        //             // Console.WriteLine($"IntrospectionEndpoint: {introspection}");
        //             // 👇 Cấu hình endpoint riêng cho introspection (nội bộ)
        //             // options.Configuration = new OpenIdConnectConfiguration
        //             // {
        //             //     Issuer = configuration["AuthServer:Authority"],

        //             //     // endpoint nội bộ - nội bộ Host gọi trực tiếp
        //             //     IntrospectionEndpoint = configuration["AuthServer:IntrospectionEndpoint"]
        //             // };

        //             // // Nếu bạn dùng UseIntrospection() ở chỗ khác thì cần clientId/secret
        //             options.TokenValidationParameters = new TokenValidationParameters
        //             {
        //                 ValidateIssuer = true,
        //                 ValidIssuer = configuration["AuthServer:Authority"],
        //                 ValidateAudience = true,
        //                 ValidAudience = "Bamboo",

        //                 // ValidateLifetime = true,
        //                 // ValidateIssuerSigningKey = true,
        //                 // IssuerSigningKey = new X509SecurityKey(cert)
        //             };
        //             options.TokenValidationParameters.ValidIssuers =
        //             [
        //                 configuration["AuthServer:Authority"]?.TrimEnd('/'),
        //                 configuration["AuthServer:Authority"]?.TrimEnd('/') + "/"
        //             ];

        //             // options.UseIntrospection()
        //             // .SetIntrospectionEndpoint("http://192.168.1.10:4000/connect/introspect")
        //             // .SetClientId("miniapp_host")
        //             // .SetClientSecret("secret");
        //         }
        //     })
        // // // Handler 2: "Bộ định tuyến" - Quyết định dùng handler nào
        // .AddPolicyScheme("Bearer", "Bearer", options =>
        // {
        //     var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
        //     var logger = loggerFactory.CreateLogger("AuthSelector");
        //     options.ForwardDefaultSelector = ctx =>
        //     {
        //         var authHeader = ctx.Request.Headers["Authorization"].FirstOrDefault();
        //         var scheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        //         if (authHeader?.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) == true)
        //         {
        //             var token = authHeader.Substring("Bearer ".Length).Trim();
        //             var jwtHandler = new JwtSecurityTokenHandler();

        //             if (jwtHandler.CanReadToken(token))
        //             {
        //                 var jwtToken = jwtHandler.ReadJwtToken(token);
        //                 var selfSignedIssuer = configuration["Auth:Jwt:Issuer"];

        //                 // Nếu issuer của token khớp với issuer tự ký -> dùng handler "SelfSignedJwt"
        //                 if (jwtToken.Issuer == selfSignedIssuer)
        //                 {
        //                     //return "SelfSignedJwt";
        //                 }
        //             }
        //         }
        //         // Mặc định, chuyển cho handler của OpenIddict bằng đúng tên scheme của nó
        //         return OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        //     };
        // })
        // ;
        //context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        //context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

        context.Services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            // Tắt tính năng tự động check user ở DB mỗi request.
            // Nếu user thuộc host, và work trên tenant data,
            options.IsDynamicClaimsEnabled = false;
        });
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var enableAbpEndPoint = configuration.GetValue("Swagger:EnableAbpEndPoint", false);
        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"]!,
            new Dictionary<string, string>
            {
                    {"Bamboo", "Bamboo API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Bamboo API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.MapType<JsonElement>(() => new OpenApiSchema
                {
                    Type = JsonSchemaType.Object,
                    AdditionalPropertiesAllowed = true
                });
                //options.CustomSchemaIds(type => type.FullName);
                options.CustomSchemaIds(type =>
                {
                    if (type.IsGenericType)
                    {
                        // Get the full name of the generic type definition (e.g., "Volo.Abp.Application.Dtos.PagedResultDto`1")
                        // and remove the generic arity part (`1)
                        var baseTypeName = type.GetGenericTypeDefinition().FullName.Split('`')[0];

                        // Get the simple names of the generic arguments (e.g., "CategoryDto")
                        var genericArgumentNames = type.GetGenericArguments()
                                                    .Select(arg => arg.Name)
                                                    .ToArray();
                        return $"{baseTypeName}_{string.Join("_", genericArgumentNames)}";
                    }
                    return type.FullName; // For non-generic types, use the full name
                });
                if (!enableAbpEndPoint)
                {
                    options.HideAbpEndpoints();
                }
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

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(configuration["App:CorsOrigins"]?
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray() ?? Array.Empty<string>())
                    //.SetIsOriginAllowed(_ => true)
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
        var useSubpath = configuration.GetValue("App:EnableSubpath", true);
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        if (useSubpath)
        {
            app.UsePathBase("/admin");
        }

        app.UseAbpRequestLocalization();
        app.UseCorrelationId();
        //app.UseStaticFiles();
        app.MapAbpStaticAssets();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();

        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();
        var enableSwagger = configuration.GetValue("Swagger:Enable", true);
        if (enableSwagger)
        {
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                if (useSubpath)
                {
                    options.SwaggerEndpoint("/admin/swagger/v1/swagger.json", "Bamboo API");
                }
                else
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bamboo API");
                }
                options.RoutePrefix = "swagger";

                var configuration = context.GetConfiguration();
                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthScopes("Bamboo");
            });
        }
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
