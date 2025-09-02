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
    public interface IIrModelFieldsAppService : IGenericApplicationService<IrModelFields>
    {
        Task<IrModelFields> FormbuilderWhitelistAsync(Guid id, IrModelFieldsFormbuilderWhitelistRequestDto input);
        Task<IrModelFields> GetFieldHelpAsync(Guid id, IrModelFieldsGetFieldHelpRequestDto input);
        Task<IrModelFields> GetFieldSelectionAsync(Guid id, IrModelFieldsGetFieldSelectionRequestDto input);
        Task<IrModelFields> GetFieldStringAsync(Guid id, IrModelFieldsGetFieldStringRequestDto input);
        Task<IrModelFields> InitAsync(Guid id);
    }
}