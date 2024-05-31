// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods to configure Social / OAuth authentication.
/// </summary>
public static class SocialAuthenticationExtensions
{
    /// <summary>
    /// </para>
    /// </summary>
    /// <param name="builder">The <see cref="AuthenticationBuilder"/>.</param>
    /// <returns>A reference to <paramref name="builder"/> after the operation has completed.</returns>
    public static AuthenticationBuilder AddDefaultSocial(this AuthenticationBuilder builder, IConfiguration configuration)
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
        section = configuration.GetSection("Authentication:Twitter");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddTwitter(options =>
            {
                options.ConsumerKey = section["ClientId"];
                options.ConsumerSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Microsoft");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddMicrosoftAccount(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
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
        section = configuration.GetSection("Authentication:Zalo");
        if (section.Exists() && section.GetValue<bool>("Enable", false))
        {
            builder.AddZalo(options =>
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
                options.AuthorizationEndpoint = section["AuthorizationEndpoint"];
                options.TokenEndpoint = section["TokenEndpoint"];
                options.UserInformationEndpoint = section["UserInformationEndpoint"];
            });
        }
        return builder;
    }
}
