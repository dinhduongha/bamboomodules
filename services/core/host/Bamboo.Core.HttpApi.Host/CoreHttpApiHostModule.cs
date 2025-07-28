using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EntityFrameworkCore.PostgreSql;

using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Security.Claims;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

using Bamboo.Core.EntityFrameworkCore;
using Bamboo.MultiTenancy;
using Volo.Abp.Auditing;
using Npgsql;
using Bamboo.Core.Application;
using Volo.Abp.Json;
using Volo.Abp.Json.SystemTextJson;

namespace Bamboo.Core;
[DependsOn(
    typeof(CoreApplicationModule),
    typeof(CoreEntityFrameworkCoreModule),
    typeof(CoreHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSharedHostingMicroservicesModule),
    typeof(AbpSwashbuckleModule)
    )]
public class CoreHttpApiHostModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        // Tắt Audit Logging
        Configure<AbpAuditingOptions>(options =>
        {
            options.IsEnabled = false; // Tắt toàn bộ Audit Logging
        });

        NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });

        // USE FOR SEED DATA 
        context.Services.AddTransient<IDataSeedService, DataSeedService>();
        context.Services.AddTransient<IJunctionTableService, JunctionTableService>();
        Configure<AbpSystemTextJsonSerializerOptions>(options =>
        {
            // Bỏ qua các thuộc tính có giá trị null khi serialize
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            
            // Tùy chọn: Thêm các cấu hình phổ biến khác nếu cần
            // options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            // options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<CoreDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}..{0}..{0}shared{0}core{0}Bamboo.Core.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CoreDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Bamboo.Core.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CoreApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}..{0}..{0}shared{0}core{0}Bamboo.Core.Application.Contracts", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<CoreApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}Bamboo.Core.Application", Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"],
            new Dictionary<string, string>
            {
                {"Core", "Core API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Core API", Version = "v1"});
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
            options.Languages.Add(new LanguageInfo("is", "is", "Icelandic"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            options.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        });

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = "Bamboo";
            });

        //Configure<AbpDistributedCacheOptions>(options =>
        //{
        //    options.KeyPrefix = "Core:";
        //});

        //var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("Core");
        //if (!hostingEnvironment.IsDevelopment())
        //{
        //    var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        //    dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "Core-Protection-Keys");
        //}

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

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }
        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        app.UseSwagger(options =>
        {
            //options.RouteTemplate = "api/v1/core/swagger/{documentName}/swagger.json";
        });
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

            //options.SwaggerEndpoint("/api/v1/core/swagger/v1/swagger.json", "Support APP API");
            //options.RoutePrefix = "api/v1/giftcard";
            //options.InjectJavascript("/swagger/ui/abp.js");
            //options.InjectJavascript("/swagger/ui/abp.swagger.js");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthScopes("openid", "profile", "email", "phone", "roles", "address", "Bamboo");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
