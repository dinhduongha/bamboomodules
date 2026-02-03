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
    public interface IAccountFiscalPositionAppService : IGenericAppService<AccountFiscalPosition>
    {
        Task<AccountFiscalPosition> ArchiveAsync(Guid[] ids);
        Task<AccountFiscalPosition> CreateForeignTaxesAsync(Guid[] ids);
        Task<AccountFiscalPosition> MapAccountAsync(AccountFiscalPositionMapAccountRequestDto input);
        Task<AccountFiscalPosition> MapTaxAsync(AccountFiscalPositionMapTaxRequestDto input);
        Task<AccountFiscalPosition> OpenRelatedTaxesAsync(Guid[] ids);
    }
}