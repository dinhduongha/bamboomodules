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
    public interface IAccountAnalyticLineAppService : IGenericApplicationService<AccountAnalyticLine>
    {
        Task<AccountAnalyticLine> GetViewsAsync(Guid id, AccountAnalyticLineGetViewsRequestDto input);
        Task<AccountAnalyticLine> InvoiceFromTimesheetAsync(Guid id);
        Task<AccountAnalyticLine> OnChangeUnitAmountAsync(Guid id);
        Task<AccountAnalyticLine> OpenTimesheetViewPortalAsync(Guid id);
        Task<AccountAnalyticLine> SaleOrderFromTimesheetAsync(Guid id);
        Task<AccountAnalyticLine> ViewHeaderGetAsync(Guid id, AccountAnalyticLineViewHeaderGetRequestDto input);
    }
}