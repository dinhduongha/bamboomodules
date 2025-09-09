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
    public interface IPurchaseRequisitionAppService : IGenericApplicationService<PurchaseRequisition>
    {
        Task<PurchaseRequisition> CancelAsync(Guid id);
        Task<PurchaseRequisition> ConfirmAsync(Guid id);
        Task<PurchaseRequisition> DoneAsync(Guid id);
        Task<PurchaseRequisition> DraftAsync(Guid id);
    }
}