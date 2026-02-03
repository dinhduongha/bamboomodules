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
    public interface IIrConfigParameterAppService : IGenericAppService<IrConfigParameter>
    {
        Task<IrConfigParameter> GetParamAsync(IrConfigParameterGetParamRequestDto input);
        Task<IrConfigParameter> InitAsync(IrConfigParameterInitRequestDto input);
        Task<IrConfigParameter> SetParamAsync(IrConfigParameterSetParamRequestDto input);
        Task<IrConfigParameter> UnlinkDefaultParametersAsync(Guid[] ids);
    }
}