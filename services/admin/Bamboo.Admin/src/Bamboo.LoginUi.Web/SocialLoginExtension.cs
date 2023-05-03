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
        if (section.Exists())
        {
            var str = section["ClientId"];
            builder.AddGoogle(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Apple");
        if (section.Exists())
        {
            builder.AddApple(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Facebook");
        if (section.Exists())
        {
            var str = section["ClientId"];
            builder.AddFacebook(options =>
            {
                options.AppId = section["ClientId"];
                options.AppSecret = section["ClientSecret"];
                options.Scope.Add("email");
                options.Scope.Add("public_profile");
            });
        }
        section = configuration.GetSection("Authentication:Twitter");
        if (section.Exists())
        {
            builder.AddTwitter(options =>
            {
                options.ConsumerKey = section["ClientId"];
                options.ConsumerSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Microsoft");
        if (section.Exists())
        {
            builder.AddMicrosoftAccount(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Instagram");
        if (section.Exists())
        {
            builder.AddInstagram(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Line");
        if (section.Exists())
        {
            var str = section["ClientId"];
            builder.AddLine(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        section = configuration.GetSection("Authentication:Zalo");
        if (section.Exists())
        {
            builder.AddZalo(options =>
            {
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
            });
        }
        return builder;
    }
}
