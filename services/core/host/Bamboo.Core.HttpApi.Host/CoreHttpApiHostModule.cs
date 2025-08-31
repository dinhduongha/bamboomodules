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
using Swashbuckle.AspNetCore.SwaggerGen;
using Volo.Abp.AspNetCore.Mvc;

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
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
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
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Core API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.DocumentFilter<ControllerOrderDocumentFilter>();
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
        app.UsePathBase("/core");
        app.UseSwagger(options =>
        {
            //options.RouteTemplate = "api/v1/core/swagger/{documentName}/swagger.json";
            
        });
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/core/swagger/v1/swagger.json", "Support APP API");

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

public class ControllerOrderDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        Apply4(swaggerDoc, context );
        // swaggerDoc.Tags = swaggerDoc.Tags
        //     .OrderBy(t => priority.IndexOf(t.Name) < 0 ? int.MaxValue : priority.IndexOf(t.Name))
        //     .ThenBy(t => t.Name)
        //     .ToList();
        // map path -> controller

    }
    public void Apply1(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    { 
        var priority = new List<string> { "GenericModel", "JsonRpc" };

        var pathToController = context.ApiDescriptions
            .GroupBy(d => "/" + d.RelativePath.TrimEnd('/'))
            .ToDictionary(
                g => g.Key,
                g => g.First().ActionDescriptor.RouteValues["controller"] ?? ""
            );

        // sort lại swaggerDoc.Paths
            var sortedPaths = swaggerDoc.Paths
                .OrderBy(kvp =>
                {
                    var controller = pathToController.TryGetValue(kvp.Key, out var c) ? c : "";
                    var idx = priority.IndexOf(controller);
                    return idx == -1 ? int.MaxValue : idx;   // ưu tiên controller trong list
                })
                .ThenBy(kvp =>
                {
                    var controller = pathToController.TryGetValue(kvp.Key, out var c) ? c : "";
                    return controller;                      // sau đó sort theo tên controller
                })
                .ThenBy(kvp => kvp.Key)                    // phụ: sort theo URL nếu cùng controller
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // gán lại
            swaggerDoc.Paths = new OpenApiPaths();
            foreach (var kvp in sortedPaths)
            {
                swaggerDoc.Paths.Add(kvp.Key, kvp.Value);
            }
    }

    public void Apply2(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    { 
        var priority = new List<string> { "GenericModel", "JsonRpc" };

        //Map Controller -> entry point đầu tiên (để xác định module)
        var controllerToPath = context.ApiDescriptions
            .GroupBy(desc => desc.ActionDescriptor.RouteValues["controller"])
            .ToDictionary(
                g => g.Key!,
                g => g.Select(d => "/" + d.RelativePath.TrimEnd('/'))
                      .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                      .FirstOrDefault() ?? ""
            );

        // Hàm lấy module name từ path (/api/app/{module}/...)
        string ExtractModule(string? path)
        {
            if (string.IsNullOrEmpty(path)) return "~";
            var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length >= 3 ? parts[2] : path;
        }

        // Controllers có trong priority list -> giữ nguyên thứ tự đó
        var priorityTags = priority
            .Select(p => swaggerDoc.Tags.FirstOrDefault(t => t.Name == p))
            .Where(t => t != null)
            .ToList();

        // Controllers còn lại -> sort theo module name
        var otherTags = swaggerDoc.Tags
            .Where(t => !priority.Contains(t.Name))
            .OrderBy(t =>
            {
                if (controllerToPath.TryGetValue(t.Name, out var path))
                {
                    return ExtractModule(path);
                }
                return "~";
            }, StringComparer.OrdinalIgnoreCase)
            .ToList();

        // Gộp lại thành list cuối cùng
        swaggerDoc.Tags = priorityTags.Concat(otherTags).ToList();
    }
    public void Apply3(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var priority = new List<string> { "GenericModel", "JsonRpc" };

        var ci = StringComparer.OrdinalIgnoreCase;

        // 2) Lấy ra danh sách controller & route values liên quan (area, controller)
        var controllerInfos = context.ApiDescriptions
            .Select(d =>
            {
                var rv = d.ActionDescriptor.RouteValues;
                rv.TryGetValue("controller", out var controller);
                rv.TryGetValue("area", out var area);
                return new { Controller = controller ?? string.Empty, Area = area ?? string.Empty };
            })
            .Where(x => !string.IsNullOrEmpty(x.Controller))
            .GroupBy(x => x.Controller, ci)
            .Select(g => new
            {
                Controller = g.Key,
                // Nếu 1 controller xuất hiện ở nhiều area, lấy area “nhỏ nhất” theo chữ cái để làm key sắp xếp ổn định
                Area = g.Select(x => x.Area ?? string.Empty).OrderBy(a => a, ci).FirstOrDefault() ?? string.Empty
            })
            .ToList();

        // 3) Danh sách tag (controller) hiện có trong doc; nếu trống, build từ controllerInfos
        var existingTagNames = (swaggerDoc.Tags?.Select(t => t.Name).ToList() ?? new List<string>());
        if (existingTagNames.Count == 0)
            existingTagNames = controllerInfos.Select(x => x.Controller).Distinct(ci).ToList();

        // 4) Map controller -> sortKey theo RouteValues (vd: "area|controller")
        var sortKeyByController = controllerInfos.ToDictionary(
            x => x.Controller,
            x => $"{x.Area}|{x.Controller}",
            ci
        );

        // 5) Chia 2 nhóm: priority và các controller còn lại
        var priorityOrdered = priority
            .Where(p => existingTagNames.Contains(p, ci))
            .ToList(); // giữ đúng thứ tự trong 'priority'

        var others = existingTagNames
            .Where(n => !priorityOrdered.Contains(n, ci))
            .OrderBy(n => sortKeyByController.TryGetValue(n, out var key) ? key : $"~|{n}", ci)
            .ToList();

        // 6) Gộp và ghi đè swaggerDoc.Tags theo thứ tự mới (chỉ ảnh hưởng danh sách controller; endpoints giữ nguyên)
        var finalTagNames = priorityOrdered.Concat(others).ToList();
        swaggerDoc.Tags = finalTagNames.Select(n => new OpenApiTag { Name = n }).ToList();
    }
    public void Apply4(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    { 
        var priority = new List<string> { "GenericModel", "JsonRpc" };
        var ci = StringComparer.OrdinalIgnoreCase;

        // 1. Lấy mapping Controller -> entry point đầu tiên (path nhỏ nhất theo chữ cái)
        var controllerToFirstPath = context.ApiDescriptions
            .GroupBy(d => d.ActionDescriptor.RouteValues["controller"])
            .Where(g => g.Key != null)
            .ToDictionary(
                g => g.Key!,
                g => g.Select(d => "/" + d.RelativePath.TrimEnd('/'))
                      .OrderBy(p => p, ci)
                      .FirstOrDefault() ?? string.Empty,
                ci
            );

        // 2. Nếu swaggerDoc.Tags rỗng thì tự build từ controller
        if (swaggerDoc.Tags == null || swaggerDoc.Tags.Count == 0)
        {
            swaggerDoc.Tags = controllerToFirstPath.Keys
                .Select(c => new OpenApiTag { Name = c })
                .ToList();
        }

        // 3. Sắp xếp Tags:
        //   - Trước tiên theo priority list
        //   - Sau đó theo path đầu tiên của controller
        swaggerDoc.Tags = swaggerDoc.Tags
            .OrderBy(t =>
            {
                var idx = priority.IndexOf(t.Name);
                return idx == -1 ? int.MaxValue : idx; // priority trước
            })
            .ThenBy(t =>
            {
                return controllerToFirstPath.TryGetValue(t.Name, out var path) ? path : "~";
            }, ci)
            .ToList();
    }
}