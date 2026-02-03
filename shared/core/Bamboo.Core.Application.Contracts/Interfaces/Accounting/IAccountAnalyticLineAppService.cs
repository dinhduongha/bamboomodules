using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountAnalyticLineAppService : IGenericApplicationService<AccountAnalyticLine>
    {
        Task<AccountAnalyticLine> GetImportTemplatesAsync(Guid[] ids);
        Task<AccountAnalyticLine> GetUnusualDaysAsync(AccountAnalyticLineGetUnusualDaysRequestDto input);
        Task<AccountAnalyticLine> GetViewsAsync(AccountAnalyticLineGetViewsRequestDto input);
        Task<AccountAnalyticLine> InvoiceFromTimesheetAsync(Guid[] ids);
        Task<AccountAnalyticLine> OnChangeUnitAmountAsync(Guid[] ids);
        Task<AccountAnalyticLine> OpenTimesheetViewPortalAsync(Guid[] ids);
        Task<AccountAnalyticLine> SaleOrderFromTimesheetAsync(Guid[] ids);
        Task<AccountAnalyticLine> ViewHeaderGetAsync(AccountAnalyticLineViewHeaderGetRequestDto input);
    }
}