using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using OpenIddict.Abstractions;
using Volo.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp.OpenIddict.Scopes;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;

namespace Bamboo.Admin.OpenIddict;

/* Creates initial data that is needed to property run the application
 * and make client-to-server communication possible.
 */
public class OpenIddictDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IConfiguration _configuration;
    private readonly IOpenIddictApplicationRepository _openIddictApplicationRepository;
    private readonly IAbpApplicationManager _applicationManager;
    private readonly IOpenIddictScopeRepository _openIddictScopeRepository;
    private readonly IOpenIddictScopeManager _scopeManager;
    private readonly IPermissionDataSeeder _permissionDataSeeder;
    private readonly IStringLocalizer<OpenIddictResponse> L;

    public OpenIddictDataSeedContributor(
        IConfiguration configuration,
        IOpenIddictApplicationRepository openIddictApplicationRepository,
        IAbpApplicationManager applicationManager,
        IOpenIddictScopeRepository openIddictScopeRepository,
        IOpenIddictScopeManager scopeManager,
        IPermissionDataSeeder permissionDataSeeder,
        IStringLocalizer<OpenIddictResponse> l)
    {
        _configuration = configuration;
        _openIddictApplicationRepository = openIddictApplicationRepository;
        _applicationManager = applicationManager;
        _openIddictScopeRepository = openIddictScopeRepository;
        _scopeManager = scopeManager;
        _permissionDataSeeder = permissionDataSeeder;
        L = l;
    }

    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        await CreateScopesAsync();
        await CreateApplicationsAsync();
    }

    private async Task CreateScopesAsync()
    {
        var scopeNames = new List<string>()
        {
            "Bamboo",
            "Admin",
            "Core",
            "Pos",
            "Crm",
            "Hrm",
            "Push",
            "Web3",
        };
        foreach (var scope in scopeNames)
        {
            if (await _openIddictScopeRepository.FindByNameAsync(scope) == null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
                {
                    Name = scope,
                    DisplayName = $"{scope} API",
                    Resources =
                {
                    scope
                }
                });
            }
        }
    }

    private async Task CreateApplicationsAsync()
    {
        var commonScopes = new List<string>
        {
            OpenIddictConstants.Permissions.Scopes.Address,
            OpenIddictConstants.Permissions.Scopes.Email,
            OpenIddictConstants.Permissions.Scopes.Phone,
            OpenIddictConstants.Permissions.Scopes.Profile,
            OpenIddictConstants.Permissions.Scopes.Roles,
            "Bamboo",
        };

        var configurationSection = _configuration.GetSection("OpenIddict:Applications");
        var sectionName = _configuration.GetValue("OpenIddict:SectionName", "");
        if (!sectionName.IsNullOrWhiteSpace())
        {
            sectionName = sectionName + "_";
        }

        //Web Client
        var webClientId = configurationSection[$"{sectionName}Web:ClientId"];
        if (!webClientId.IsNullOrWhiteSpace())
        {
            var webClientRootUrl = configurationSection[$"{sectionName}Web:RootUrl"]!.EnsureEndsWith('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}Web:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}Web:PostLogoutRedirectUris").Get<List<string>>();
            /* Admin_Web client is only needed if you created a tiered
             * solution. Otherwise, you can delete this client. */
            await CreateApplicationAsync(
                name: webClientId!,
                type: OpenIddictConstants.ClientTypes.Confidential,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Web MVC Application",
                secret: configurationSection[$"{sectionName}Web:ClientSecret"] ?? "1q2w3E*",
                grantTypes: new List<string> //Hybrid flow
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.Implicit
                },
                scopes: commonScopes,
                redirectUri: $"{webClientRootUrl}signin-oidc",
                clientUri: webClientRootUrl,
                redirectUris: redirectUris,
                postLogoutRedirectUri: $"{webClientRootUrl}signout-callback-oidc",
                postLogoutRedirectUris: postLogoutRedirectUris
            );
        }

        // Blazor WebApp Tiered Client
        var blazorWebAppTieredClientId = configurationSection[$"{sectionName}BlazorWebAppTiered:ClientId"];
        if (!blazorWebAppTieredClientId.IsNullOrWhiteSpace())
        {
            var blazorWebAppTieredRootUrl = configurationSection[$"{sectionName}BlazorWebAppTiered:RootUrl"]!.EnsureEndsWith('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}BlazorWebAppTiered:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}BlazorWebAppTiered:PostLogoutRedirectUris").Get<List<string>>();
            await CreateApplicationAsync(
                name: blazorWebAppTieredClientId!,
                type: OpenIddictConstants.ClientTypes.Confidential,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Blazor WebApp Application",
                secret: configurationSection[$"{sectionName}BlazorWebAppTiered:ClientSecret"] ?? "1q2w3e*",
                grantTypes: new List<string> //Hybrid flow
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.Implicit
                },
                scopes: commonScopes,
                redirectUri: $"{blazorWebAppTieredRootUrl}signin-oidc",
                clientUri: blazorWebAppTieredRootUrl,
                redirectUris: redirectUris,
                postLogoutRedirectUri: $"{blazorWebAppTieredRootUrl}signout-callback-oidc",
                postLogoutRedirectUris: postLogoutRedirectUris
            );
        }

        // Blazor Server Tiered Client
        var blazorServerTieredClientId = configurationSection[$"{sectionName}BlazorServerTiered:ClientId"];
        if (!blazorServerTieredClientId.IsNullOrWhiteSpace())
        {
            var blazorServerTieredRootUrl = configurationSection[$"{sectionName}BlazorServerTiered:RootUrl"]!.EnsureEndsWith('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}BlazorServerTiered:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}BlazorServerTiered:PostLogoutRedirectUris").Get<List<string>>();
            await CreateApplicationAsync(
                name: blazorServerTieredClientId!,
                type: OpenIddictConstants.ClientTypes.Confidential,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Blazor Server Application",
                secret: configurationSection[$"{sectionName}BlazorServerTiered:ClientSecret"] ?? "1q2w3E*",
                grantTypes: new List<string> //Hybrid flow
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.Implicit
                },
                scopes: commonScopes,
                redirectUri: $"{blazorServerTieredRootUrl}signin-oidc",
                clientUri: blazorServerTieredRootUrl,
                redirectUris: redirectUris,
                postLogoutRedirectUri: $"{blazorServerTieredRootUrl}signout-callback-oidc",
                postLogoutRedirectUris: postLogoutRedirectUris
            );
        }
        // Mobile Client
        var MobileClientId = configurationSection[$"{sectionName}Mobile:ClientId"];
        if (!MobileClientId.IsNullOrWhiteSpace())
        {
            var MobileRootUrl = configurationSection[$"{sectionName}Mobile:RootUrl"]!.EnsureEndsWith('/');
            var mobileScopes = commonScopes;
            mobileScopes.AddFirst("offline_access");
            await CreateApplicationAsync(
                name: MobileClientId,
                type: OpenIddictConstants.ClientTypes.Confidential,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Mobile Application",
                scopes: mobileScopes,
                grantTypes: new List<string>
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.Password
                },
                secret: configurationSection[$"{sectionName}Mobile:ClientSecret"] ?? "1q2w3E*",
                redirectUri: $"{MobileRootUrl}authenticated",
                redirectUris: null,
                postLogoutRedirectUri: $"{MobileRootUrl}signout-callback-oidc"
            //corsOrigins: new[] { MobileRootUrl.RemovePostFix("/") }
            );
        }

        //Console Test / Angular Client
        var consoleAndAngularClientId = configurationSection[$"{sectionName}App:ClientId"];
        if (!consoleAndAngularClientId.IsNullOrWhiteSpace())
        {
            var consoleAndAngularClientRootUrl = configurationSection[$"{sectionName}App:RootUrl"]?.TrimEnd('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}App:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}App:PostLogoutRedirectUris").Get<List<string>>();
            await CreateApplicationAsync(
                name: consoleAndAngularClientId!,
                type: OpenIddictConstants.ClientTypes.Public,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Console / Angular Application",
                secret: null,
                grantTypes: new List<string>
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.Password,
                    OpenIddictConstants.GrantTypes.ClientCredentials,
                    OpenIddictConstants.GrantTypes.RefreshToken
                },
                scopes: commonScopes,
                redirectUri: consoleAndAngularClientRootUrl,
                clientUri: consoleAndAngularClientRootUrl,
                redirectUris: redirectUris,
                postLogoutRedirectUri: consoleAndAngularClientRootUrl,
                postLogoutRedirectUris: postLogoutRedirectUris
            );
        }

        // Blazor Wasm Client
        var blazorClientId = configurationSection[$"{sectionName}Blazor:ClientId"];
        if (!blazorClientId.IsNullOrWhiteSpace())
        {
            var blazorRootUrl = configurationSection[$"{sectionName}Blazor:RootUrl"]?.TrimEnd('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}Blazor:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}Blazor:PostLogoutRedirectUris").Get<List<string>>();
            await CreateApplicationAsync(
                name: blazorClientId!,
                type: OpenIddictConstants.ClientTypes.Public,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Blazor Application",
                secret: null,
                grantTypes: new List<string>
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.ClientCredentials,
                    OpenIddictConstants.GrantTypes.Password,
                    OpenIddictConstants.GrantTypes.RefreshToken,
                    "switch_tenant"
                },
                scopes: commonScopes,
                redirectUri: $"{blazorRootUrl}/authentication/login-callback",
                clientUri: blazorRootUrl,
                redirectUris: redirectUris,
                postLogoutRedirectUri: $"{blazorRootUrl}/authentication/logout-callback",
                postLogoutRedirectUris: postLogoutRedirectUris
            );
        }

        //Flutter Client
        var flutterClientId = configurationSection[$"{sectionName}FlutterApp:ClientId"];
        if (!flutterClientId.IsNullOrWhiteSpace())
        {
            var flutterClientRootUrl = configurationSection[$"{sectionName}FlutterApp:RootUrl"]?.TrimEnd('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}FlutterApp:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}FlutterApp:PostLogoutRedirectUris").Get<List<string>>();
            var mobileScopes = commonScopes;
            mobileScopes.AddFirst("offline_access");

            await CreateApplicationAsync(
                name: flutterClientId!,
                type: OpenIddictConstants.ClientTypes.Public,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Flutter Application",
                //secret: configurationSection[$"{sectionName}FlutterApp:ClientSecret"]!,
                secret: null,
                grantTypes: new List<string> {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.GrantTypes.Password,
                    OpenIddictConstants.GrantTypes.ClientCredentials,
                    OpenIddictConstants.GrantTypes.RefreshToken,
                    "switch_tenant"
                },
                scopes: mobileScopes,
                redirectUri: $"{flutterClientRootUrl}/auth.html",
                clientUri: flutterClientRootUrl,
                postLogoutRedirectUri: flutterClientRootUrl,
                redirectUris: redirectUris,
                postLogoutRedirectUris: postLogoutRedirectUris
            );
        }

        // React Client
        var reactClientId = configurationSection[$"{sectionName}React:ClientId"];
        if (!reactClientId.IsNullOrWhiteSpace())
        {
            var reactClientRootUrl = configurationSection[$"{sectionName}React:RootUrl"]?.TrimEnd('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}React:RedirectUris").Get<List<string>>();
            var postLogoutRedirectUris = configurationSection.GetSection($"{sectionName}React:PostLogoutRedirectUris").Get<List<string>>();
            try
            {
                await CreateApplicationAsync(
                    name: reactClientId,
                    type: OpenIddictConstants.ClientTypes.Public,
                    consentType: OpenIddictConstants.ConsentTypes.Implicit,
                    displayName: "React Application",
                    secret: null,
                    grantTypes: new List<string>
                    {
                        OpenIddictConstants.GrantTypes.AuthorizationCode,
                        OpenIddictConstants.GrantTypes.Password,
                        OpenIddictConstants.GrantTypes.ClientCredentials,
                        OpenIddictConstants.GrantTypes.RefreshToken,
                        "switch_tenant",
                        "siwx"
                    },
                    scopes: commonScopes,
                    clientUri: reactClientRootUrl,
                    redirectUri: $"{reactClientRootUrl}/auth/openiddict",
                    redirectUris: redirectUris,
                    postLogoutRedirectUri: $"{reactClientRootUrl}/auth/openiddict/logout-callback",
                    postLogoutRedirectUris: postLogoutRedirectUris
                    //redirectUris: reactClientRootUrl.Select(x => $"{x}/auth/openiddict").ToArray(),
                    //postLogoutRedirectUris: reactClientRootUrl
                    );
            }
            catch (Exception e)
            {
                throw;
            }
        }
        // Swagger Client
        var swaggerClientId = configurationSection[$"{sectionName}Swagger:ClientId"];
        if (!swaggerClientId.IsNullOrWhiteSpace())
        {
            var swaggerRootUrl = configurationSection[$"{sectionName}Swagger:RootUrl"]?.TrimEnd('/');
            var redirectUris = configurationSection.GetSection($"{sectionName}Swagger:RedirectUris").Get<List<string>>();
            await CreateApplicationAsync(
                name: swaggerClientId!,
                type: OpenIddictConstants.ClientTypes.Public,
                consentType: OpenIddictConstants.ConsentTypes.Implicit,
                displayName: "Swagger Application",
                secret: null,
                grantTypes: new List<string>
                {
                    OpenIddictConstants.GrantTypes.AuthorizationCode,
                    "switch_tenant",
                    "siwx"
                },
                scopes: commonScopes,
                redirectUri: $"{swaggerRootUrl}/swagger/oauth2-redirect.html",
                clientUri: swaggerRootUrl,
                redirectUris: redirectUris
            );
        }
    }

    private async Task CreateApplicationAsync(
        [NotNull] string name,
        [NotNull] string type,
        [NotNull] string consentType,
        string displayName,
        string? secret,
        List<string> grantTypes,
        List<string> scopes,
        string? clientUri = null,
        string? redirectUri = null,
        string? postLogoutRedirectUri = null,
        List<string>? permissions = null,
        List<string>? redirectUris = null,
        List<string>? postLogoutRedirectUris = null
        )
    {
        if (!string.IsNullOrEmpty(secret) && string.Equals(type, OpenIddictConstants.ClientTypes.Public,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new BusinessException(L["NoClientSecretCanBeSetForPublicApplications"]);
        }

        if (string.IsNullOrEmpty(secret) && string.Equals(type, OpenIddictConstants.ClientTypes.Confidential,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new BusinessException(L["TheClientSecretIsRequiredForConfidentialApplications"]);
        }

        var client = await _openIddictApplicationRepository.FindByClientIdAsync(name);
        var application = new AbpApplicationDescriptor
        {
            ClientId = name,
            ClientType = type,
            ClientSecret = secret,
            ConsentType = consentType,
            DisplayName = displayName,
            ClientUri = clientUri,
        };

        Check.NotNullOrEmpty(grantTypes, nameof(grantTypes));
        Check.NotNullOrEmpty(scopes, nameof(scopes));

        if (new[] { OpenIddictConstants.GrantTypes.AuthorizationCode, OpenIddictConstants.GrantTypes.Implicit }.All(grantTypes.Contains))
        {
            application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.CodeIdToken);

            if (string.Equals(type, OpenIddictConstants.ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.CodeIdTokenToken);
                application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.CodeToken);
            }
        }

        if (!redirectUri.IsNullOrWhiteSpace() || !postLogoutRedirectUri.IsNullOrWhiteSpace())
        {
            application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.EndSession);
        }

        var buildInGrantTypes = new[]
        {
                OpenIddictConstants.GrantTypes.Implicit,
                OpenIddictConstants.GrantTypes.Password,
                OpenIddictConstants.GrantTypes.AuthorizationCode,
                OpenIddictConstants.GrantTypes.ClientCredentials,
                OpenIddictConstants.GrantTypes.DeviceCode,
                OpenIddictConstants.GrantTypes.RefreshToken,
                "gt:switch_tenant"
        };

        foreach (var grantType in grantTypes)
        {
            if (grantType == OpenIddictConstants.GrantTypes.AuthorizationCode)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode);
                application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.Code);
            }

            if (grantType == OpenIddictConstants.GrantTypes.AuthorizationCode || grantType == OpenIddictConstants.GrantTypes.Implicit)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Authorization);
            }

            if (grantType == OpenIddictConstants.GrantTypes.AuthorizationCode ||
                grantType == OpenIddictConstants.GrantTypes.ClientCredentials ||
                grantType == OpenIddictConstants.GrantTypes.Password ||
                grantType == OpenIddictConstants.GrantTypes.RefreshToken ||
                grantType == OpenIddictConstants.GrantTypes.DeviceCode)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Token);
                application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Revocation);
                application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Introspection);
            }

            if (grantType == OpenIddictConstants.GrantTypes.ClientCredentials)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.ClientCredentials);
            }

            if (grantType == OpenIddictConstants.GrantTypes.Implicit)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.Implicit);
            }

            if (grantType == OpenIddictConstants.GrantTypes.Password)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.Password);
            }

            if (grantType == OpenIddictConstants.GrantTypes.RefreshToken)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.RefreshToken);
            }

            if (grantType == OpenIddictConstants.GrantTypes.DeviceCode)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.GrantTypes.DeviceCode);
                // TODO:
                //application.Permissions.Add(OpenIddictConstants.Permissions.Endpoints.Device);
            }

            if (grantType == OpenIddictConstants.GrantTypes.Implicit)
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.IdToken);
                if (string.Equals(type, OpenIddictConstants.ClientTypes.Public, StringComparison.OrdinalIgnoreCase))
                {
                    application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.IdTokenToken);
                    application.Permissions.Add(OpenIddictConstants.Permissions.ResponseTypes.Token);
                }
            }

            if (!buildInGrantTypes.Contains(grantType))
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.Prefixes.GrantType + grantType);
            }
        }

        var buildInScopes = new[]
        {
                OpenIddictConstants.Permissions.Scopes.Address,
                OpenIddictConstants.Permissions.Scopes.Email,
                OpenIddictConstants.Permissions.Scopes.Phone,
                OpenIddictConstants.Permissions.Scopes.Profile,
                OpenIddictConstants.Permissions.Scopes.Roles
            };

        foreach (var scope in scopes)
        {
            if (buildInScopes.Contains(scope))
            {
                application.Permissions.Add(scope);
            }
            else
            {
                application.Permissions.Add(OpenIddictConstants.Permissions.Prefixes.Scope + scope);
            }
        }

        if (redirectUri != null)
        {
            if (!redirectUri.IsNullOrEmpty())
            {
                if (!Uri.TryCreate(redirectUri, UriKind.Absolute, out var uri) || !uri.IsWellFormedOriginalString())
                {
                    throw new BusinessException(L["InvalidRedirectUri", redirectUri]);
                }

                if (application.RedirectUris.All(x => x != uri))
                {
                    application.RedirectUris.Add(uri);
                }
            }
        }
        if (redirectUris != null)
        {
            foreach (var r in redirectUris)
            {
                if (!r.IsNullOrEmpty())
                {
                    var redirect = r.TrimEnd('/');
                    if (!Uri.TryCreate(redirect, UriKind.Absolute, out var uri) || !uri.IsWellFormedOriginalString())
                    {
                        throw new BusinessException(L["InvalidRedirectUri", redirect]);
                    }

                    if (application.RedirectUris.All(x => x != uri))
                    {
                        application.RedirectUris.Add(uri);
                    }
                }
            }
        }
        if (postLogoutRedirectUri != null)
        {
            if (!postLogoutRedirectUri.IsNullOrEmpty())
            {
                if (!Uri.TryCreate(postLogoutRedirectUri, UriKind.Absolute, out var uri) || !uri.IsWellFormedOriginalString())
                {
                    throw new BusinessException(L["InvalidPostLogoutRedirectUri", postLogoutRedirectUri]);
                }

                if (application.PostLogoutRedirectUris.All(x => x != uri))
                {
                    application.PostLogoutRedirectUris.Add(uri);
                }
            }
        }
        if (postLogoutRedirectUris != null)
        {
            foreach (var p in postLogoutRedirectUris)
            {
                if (!p.IsNullOrEmpty())
                {
                    var redirect = p.TrimEnd('/');
                    if (!Uri.TryCreate(redirect, UriKind.Absolute, out var uri) || !uri.IsWellFormedOriginalString())
                    {
                        throw new BusinessException(L["InvalidRedirectUri", redirect]);
                    }

                    if (application.PostLogoutRedirectUris.All(x => x != uri))
                    {
                        application.PostLogoutRedirectUris.Add(uri);
                    }
                }
            }
        }
        if (permissions != null)
        {
            await _permissionDataSeeder.SeedAsync(
                ClientPermissionValueProvider.ProviderName,
                name,
                permissions,
                null
            );
        }
        if (client == null)
        {
            await _applicationManager.CreateAsync(application);
            return;
        }

        if (!HasSameRedirectUris(client, application))
        {
            client.RedirectUris = JsonSerializer.Serialize(application.RedirectUris.Select(q => q.ToString().TrimEnd('/')));
            client.PostLogoutRedirectUris = JsonSerializer.Serialize(application.PostLogoutRedirectUris.Select(q => q.ToString().TrimEnd('/')));

            await _applicationManager.UpdateAsync(client.ToModel());
        }

        if (!HasSameScopes(client, application))
        {
            client.Permissions = JsonSerializer.Serialize(application.Permissions.Select(q => q.ToString()));
            await _applicationManager.UpdateAsync(client.ToModel());
        }
    }

    private bool HasSameRedirectUris(OpenIddictApplication existingClient, AbpApplicationDescriptor application)
    {
        return existingClient.RedirectUris == JsonSerializer.Serialize(application.RedirectUris.Select(q => q.ToString().TrimEnd('/')));
    }

    private bool HasSameScopes(OpenIddictApplication existingClient, AbpApplicationDescriptor application)
    {
        return existingClient.Permissions == JsonSerializer.Serialize(application.Permissions.Select(q => q.ToString().TrimEnd('/')));
    }
}
