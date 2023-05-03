using System.Text.Json.Serialization;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

using StackExchange.Redis;

using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Swashbuckle;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;

//using AbpShared.Hosting.AspNetCore;

[DependsOn(
	typeof(AbpAutofacModule),
    typeof(AbpDataModule),
	typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpSwashbuckleModule),
    //typeof(AbpEventBusRabbitMqModule),
    //typeof(AbpBackgroundJobsRabbitMqModule),
    //typeof(AbpSharedHostingAspNetCoreModule),
	typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule)
)]
public class AbpSharedHostingMicroservicesModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    	// https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        var configuration = context.Services.GetConfiguration();
        Configure<JsonOptions>(jsonOptions =>
        {
            jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "Bamboo";
        });

        var redisOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
        bool enabledRedis = Convert.ToBoolean(configuration["Redis:IsEnabled"]);
        redisOptions.User = configuration["Redis:User"];
        redisOptions.Password = configuration["Redis:Password"];

        Configure<RedisCacheOptions>(options =>
        {
            options.Configuration = configuration["Redis:Configuration"];
            //var configurationOptions = ConfigurationOptions.Parse(configuration["Redis:Configuration"]);
            //configurationOptions.User = configuration["Redis:User"];
            //configurationOptions.Password = configuration["Redis:Password"];
            options.ConfigurationOptions = redisOptions;
        });
        
        var redis = ConnectionMultiplexer.Connect(redisOptions);
        context.Services
            .AddDataProtection()
            .PersistKeysToStackExchangeRedis(redis, "Bamboo-Protection-Keys");
            
        context.Services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var connection = ConnectionMultiplexer.Connect(redisOptions);
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
		
    }
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        // app.UseSwagger(options =>
        // {
        //     //options.RouteTemplate = "api/v1/myname/swagger/{documentName}/swagger.json";
        // });

        // app.UseAbpSwaggerUI(options =>
        // {
        //     options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

        //     //options.SwaggerEndpoint("/api/v1/myname/swagger/v1/swagger.json", "Support APP API");
        //     //options.RoutePrefix = "api/v1/myname";
        //     //options.InjectJavascript("/swagger/ui/abp.js");
        //     //options.InjectJavascript("/swagger/ui/abp.swagger.js");

        //     var configuration = context.GetConfiguration();
        //     options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        //     options.OAuthScopes("Starify");
        // });
    }
}