using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bamboo.Core.Application;
public interface IDataSeedService : IApplicationService
{
    Task SeedDataAsync(List<string> paths, Guid? tenantId = null, bool includeDemoData = false);
}