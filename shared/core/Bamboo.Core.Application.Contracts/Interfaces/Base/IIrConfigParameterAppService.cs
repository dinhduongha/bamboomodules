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
    public interface IIrConfigParameterAppService : IGenericApplicationService<IrConfigParameter>
    {
        Task<IrConfigParameter> GetParamAsync(Guid id, IrConfigParameterGetParamRequestDto input);
        Task<IrConfigParameter> InitAsync(Guid id, IrConfigParameterInitRequestDto input);
        Task<IrConfigParameter> SetParamAsync(Guid id, IrConfigParameterSetParamRequestDto input);
        Task<IrConfigParameter> UnlinkDefaultParametersAsync(Guid id);
    }
}