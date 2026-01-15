using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

using Bamboo.Core.Models;

namespace Bamboo.Core.Application;

public interface IDataSeedService : IApplicationService
{
    Task SeedDataAsync(List<string> paths, Guid? tenantId = null, bool includeDemoData = false);

    Task<ResCompany> SeedTenantDataAsync(Guid? tenantId = null, string? name = null);

    Task<ResUsers> SeedUserDataAsync(Guid? userId = null, string? name = null);
}