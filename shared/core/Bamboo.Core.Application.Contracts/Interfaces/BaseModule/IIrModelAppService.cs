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
    public interface IIrModelAppService : IGenericApplicationService<IrModel>
    {
        Task<IrModel> DisplayNameForAsync(Guid id, IrModelDisplayNameForRequestDto input);
        Task<IrModel> GetAuthorizedFieldsAsync(Guid id, IrModelGetAuthorizedFieldsRequestDto input);
        Task<IrModel> GetAvailableModelsAsync(Guid id);
        Task<IrModel> GetCompatibleFormModelsAsync(Guid id);
    }
}