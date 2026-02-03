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
    public interface IIrModelFieldsAppService : IGenericAppService<IrModelFields>
    {
        Task<IrModelFields> FormbuilderWhitelistAsync(IrModelFieldsFormbuilderWhitelistRequestDto input);
        Task<IrModelFields> GetFieldHelpAsync(IrModelFieldsGetFieldHelpRequestDto input);
        Task<IrModelFields> GetFieldSelectionAsync(IrModelFieldsGetFieldSelectionRequestDto input);
        Task<IrModelFields> GetFieldStringAsync(IrModelFieldsGetFieldStringRequestDto input);
        Task<IrModelFields> InitAsync(Guid[] ids);
    }
}