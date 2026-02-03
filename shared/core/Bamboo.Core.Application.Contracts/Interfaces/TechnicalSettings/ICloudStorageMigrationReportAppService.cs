using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ICloudStorageMigrationReportAppService : IApplicationService
    {
        Task<CloudStorageMigrationReport> GetProgressAsync(Guid[] ids);
        Task<CloudStorageMigrationReport> InitAsync(Guid[] ids);
    }
}