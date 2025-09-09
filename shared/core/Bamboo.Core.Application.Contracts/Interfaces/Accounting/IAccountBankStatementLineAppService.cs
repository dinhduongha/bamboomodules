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
    public interface IAccountBankStatementLineAppService : IGenericApplicationService<AccountBankStatementLine>
    {
        Task<AccountBankStatementLine> InitAsync(Guid id);
        Task<AccountBankStatementLine> NewAsync(Guid id, AccountBankStatementLineNewRequestDto input);
        Task<AccountBankStatementLine> UndoReconciliationAsync(Guid id);
    }
}