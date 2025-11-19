﻿using Microsoft.Extensions.Localization;
using Bamboo.Admin.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Admin;

[Dependency(ReplaceServices = true)]
public class AdminBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AdminResource> _localizer;

    public AdminBrandingProvider(IStringLocalizer<AdminResource> localizer)
    {
        _localizer = localizer;
    }

    //public override string AppName => "Admin";
    public override string AppName => _localizer["AppName"];
}
