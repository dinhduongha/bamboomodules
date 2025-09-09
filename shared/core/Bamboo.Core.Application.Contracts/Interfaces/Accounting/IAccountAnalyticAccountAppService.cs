using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountAnalyticAccountAppService : IGenericApplicationService<AccountAnalyticAccount>
    {
        Task<AccountAnalyticAccount> CopyDataAsync(Guid id, AccountAnalyticAccountCopyDataRequestDto input);
        Task<AccountAnalyticAccount> ViewInvoiceAsync(Guid id);
        Task<AccountAnalyticAccount> ViewMrpBomAsync(Guid id);
        Task<AccountAnalyticAccount> ViewMrpProductionAsync(Guid id);
        Task<AccountAnalyticAccount> ViewProjectsAsync(Guid id);
        Task<AccountAnalyticAccount> ViewPurchaseOrdersAsync(Guid id);
        Task<AccountAnalyticAccount> ViewVendorBillAsync(Guid id);
        Task<AccountAnalyticAccount> ViewWorkorderAsync(Guid id);
        Task<List<Dictionary<string, object>>> WebReadAsync(Guid id, AccountAnalyticAccountWebReadRequestDto input);
    }
}