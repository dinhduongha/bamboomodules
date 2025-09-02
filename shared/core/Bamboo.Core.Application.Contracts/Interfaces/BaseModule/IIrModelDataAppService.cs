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
    public interface IIrModelDataAppService : IGenericApplicationService<IrModelData>
    {
        Task<IrModelData> CheckObjectReferenceAsync(Guid id, IrModelDataCheckObjectReferenceRequestDto input);
        Task<IrModelData> CopyDataAsync(Guid id, IrModelDataCopyDataRequestDto input);
        Task<IrModelData> ToggleNoupdateAsync(Guid id, IrModelDataToggleNoupdateRequestDto input);
    }
}