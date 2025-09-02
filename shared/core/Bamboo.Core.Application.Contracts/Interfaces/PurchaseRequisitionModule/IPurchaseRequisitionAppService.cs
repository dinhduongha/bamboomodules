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
    public interface IPurchaseRequisitionAppService : IGenericApplicationService<PurchaseRequisition>
    {
        Task<PurchaseRequisition> CancelAsync(Guid id);
        Task<PurchaseRequisition> ConfirmAsync(Guid id);
        Task<PurchaseRequisition> DoneAsync(Guid id);
        Task<PurchaseRequisition> DraftAsync(Guid id);
    }
}