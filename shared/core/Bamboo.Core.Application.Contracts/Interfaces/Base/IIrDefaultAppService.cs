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
    public interface IIrDefaultAppService : IGenericApplicationService<IrDefault>
    {
        Task<IrDefault> DiscardRecordsAsync(Guid id, IrDefaultDiscardRecordsRequestDto input);
        Task<IrDefault> DiscardValuesAsync(Guid id, IrDefaultDiscardValuesRequestDto input);
        Task<IrDefault> SetAsync(Guid id, IrDefaultSetRequestDto input);
    }
}