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
    public interface IIrModelAppService : IGenericApplicationService<IrModel>
    {
        Task<IrModel> DisplayNameForAsync(IrModelDisplayNameForRequestDto input);
        Task<IrModel> GetAuthorizedFieldsAsync(IrModelGetAuthorizedFieldsRequestDto input);
        Task<IrModel> GetAvailableModelsAsync(Guid[] ids);
        Task<IrModel> GetCompatibleFormModelsAsync(Guid[] ids);
        Task<IrModel> HasSearchableParentRelationAsync(IrModelHasSearchableParentRelationRequestDto input);
    }
}