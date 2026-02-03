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
    public interface IAccountAnalyticAccountAppService : IGenericAppService<AccountAnalyticAccount>
    {
        Task<AccountAnalyticAccount> CopyDataAsync(AccountAnalyticAccountCopyDataRequestDto input);
        Task<AccountAnalyticAccount> ViewInvoiceAsync(Guid[] ids);
        Task<AccountAnalyticAccount> ViewMrpBomAsync(Guid[] ids);
        Task<AccountAnalyticAccount> ViewMrpProductionAsync(Guid[] ids);
        Task<AccountAnalyticAccount> ViewProjectsAsync(Guid[] ids);
        Task<AccountAnalyticAccount> ViewPurchaseOrdersAsync(Guid[] ids);
        Task<AccountAnalyticAccount> ViewVendorBillAsync(Guid[] ids);
        Task<AccountAnalyticAccount> ViewWorkorderAsync(Guid[] ids);
        Task<List<Dictionary<string, object>>> WebReadAsync(AccountAnalyticAccountWebReadRequestDto input);
    }
}