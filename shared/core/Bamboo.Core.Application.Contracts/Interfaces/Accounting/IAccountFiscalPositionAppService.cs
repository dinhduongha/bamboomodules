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
    public interface IAccountFiscalPositionAppService : IGenericApplicationService<AccountFiscalPosition>
    {
        Task<AccountFiscalPosition> ArchiveAsync(Guid id);
        Task<AccountFiscalPosition> CreateForeignTaxesAsync(Guid id);
        Task<AccountFiscalPosition> MapAccountAsync(Guid id, AccountFiscalPositionMapAccountRequestDto input);
        Task<AccountFiscalPosition> MapTaxAsync(Guid id, AccountFiscalPositionMapTaxRequestDto input);
        Task<AccountFiscalPosition> OpenRelatedTaxesAsync(Guid id);
    }
}