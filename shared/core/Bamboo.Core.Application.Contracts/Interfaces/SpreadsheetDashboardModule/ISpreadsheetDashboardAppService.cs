using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface ISpreadsheetDashboardAppService : IGenericApplicationService<SpreadsheetDashboard>
    {
        Task<SpreadsheetDashboard> CopyDataAsync(Guid id, SpreadsheetDashboardCopyDataRequestDto input);
        Task<SpreadsheetDashboard> GetReadonlyDashboardAsync(Guid id);
    }
}