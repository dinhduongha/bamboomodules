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
    public interface IIrConfigParameterAppService : IGenericApplicationService<IrConfigParameter>
    {
        Task<IrConfigParameter> GetParamAsync(Guid id, IrConfigParameterGetParamRequestDto input);
        Task<IrConfigParameter> InitAsync(Guid id, IrConfigParameterInitRequestDto input);
        Task<IrConfigParameter> SetParamAsync(Guid id, IrConfigParameterSetParamRequestDto input);
        Task<IrConfigParameter> UnlinkDefaultParametersAsync(Guid id);
    }
}