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
    public interface IIrModelAppService : IGenericApplicationService<IrModel>
    {
        Task<IrModel> DisplayNameForAsync(Guid id, IrModelDisplayNameForRequestDto input);
        Task<IrModel> GetAuthorizedFieldsAsync(Guid id, IrModelGetAuthorizedFieldsRequestDto input);
        Task<IrModel> GetAvailableModelsAsync(Guid id);
        Task<IrModel> GetCompatibleFormModelsAsync(Guid id);
    }
}