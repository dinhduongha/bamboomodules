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
    public interface IAccountReconcileModelAppService : IGenericAppService<AccountReconcileModel>
    {
        Task<AccountReconcileModel> CopyDataAsync(AccountReconcileModelCopyDataRequestDto input);
        Task<AccountReconcileModel> ReconcileStatAsync(Guid[] ids);
        Task<AccountReconcileModel> SetAutoReconcileAsync(Guid[] ids);
        Task<AccountReconcileModel> SetManualAsync(Guid[] ids);
    }
}