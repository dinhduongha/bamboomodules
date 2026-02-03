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
    public interface IPurchaseRequisitionAppService : IGenericAppService<PurchaseRequisition>
    {
        Task<PurchaseRequisition> CancelAsync(Guid[] ids);
        Task<PurchaseRequisition> ConfirmAsync(Guid[] ids);
        Task<PurchaseRequisition> DoneAsync(Guid[] ids);
        Task<PurchaseRequisition> DraftAsync(Guid[] ids);
    }
}