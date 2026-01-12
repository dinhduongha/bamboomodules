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
    public interface IAccountReconcileModelAppService : IGenericApplicationService<AccountReconcileModel>
    {
        Task<AccountReconcileModel> CopyDataAsync(Guid id, AccountReconcileModelCopyDataRequestDto input);
        Task<AccountReconcileModel> ReconcileStatAsync(Guid id);
    }
}