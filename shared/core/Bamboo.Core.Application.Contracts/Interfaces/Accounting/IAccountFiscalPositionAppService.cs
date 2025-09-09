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
    public interface IAccountFiscalPositionAppService : IGenericApplicationService<AccountFiscalPosition>
    {
        Task<AccountFiscalPosition> AdjustValsCountryIdAsync(Guid id, AccountFiscalPositionAdjustValsCountryIdRequestDto input);
        Task<AccountFiscalPosition> CreateForeignTaxesAsync(Guid id);
        Task<AccountFiscalPosition> MapAccountAsync(Guid id, AccountFiscalPositionMapAccountRequestDto input);
        Task<AccountFiscalPosition> MapTaxAsync(Guid id, AccountFiscalPositionMapTaxRequestDto input);
        Task<AccountFiscalPosition> RaiseVatErrorMessageAsync(Guid id, AccountFiscalPositionRaiseVatErrorMessageRequestDto input);
    }
}