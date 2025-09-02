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
    public interface IAccountBankStatementLineAppService : IGenericApplicationService<AccountBankStatementLine>
    {
        Task<AccountBankStatementLine> InitAsync(Guid id);
        Task<AccountBankStatementLine> NewAsync(Guid id, AccountBankStatementLineNewRequestDto input);
        Task<AccountBankStatementLine> UndoReconciliationAsync(Guid id);
    }
}