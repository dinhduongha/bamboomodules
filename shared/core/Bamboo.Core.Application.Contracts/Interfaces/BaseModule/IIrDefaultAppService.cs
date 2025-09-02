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
    public interface IIrDefaultAppService : IGenericApplicationService<IrDefault>
    {
        Task<IrDefault> DiscardRecordsAsync(Guid id, IrDefaultDiscardRecordsRequestDto input);
        Task<IrDefault> DiscardValuesAsync(Guid id, IrDefaultDiscardValuesRequestDto input);
        Task<IrDefault> SetAsync(Guid id, IrDefaultSetRequestDto input);
    }
}