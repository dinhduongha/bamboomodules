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
    public interface IIrModelDataAppService : IGenericApplicationService<IrModelData>
    {
        Task<IrModelData> CheckObjectReferenceAsync(Guid id, IrModelDataCheckObjectReferenceRequestDto input);
        Task<IrModelData> CopyDataAsync(Guid id, IrModelDataCopyDataRequestDto input);
        Task<IrModelData> ToggleNoupdateAsync(Guid id, IrModelDataToggleNoupdateRequestDto input);
    }
}