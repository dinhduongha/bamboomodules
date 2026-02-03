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
    public interface IIrAttachmentAppService : IGenericAppService<IrAttachment>
    {
        Task<IrAttachment> CheckAsync(IrAttachmentCheckRequestDto input);
        Task<IrAttachment> CopyDataAsync(IrAttachmentCopyDataRequestDto input);
        Task<IrAttachment> CreateUniqueAsync(IrAttachmentCreateUniqueRequestDto input);
        Task<IrAttachment> ForceStorageAsync(Guid[] ids);
        Task<IrAttachment> GenerateAccessTokenAsync(Guid[] ids);
        Task<IrAttachment> GetAsync(Guid[] ids);
        Task<IrAttachment> GetServingGroupsAsync(Guid[] ids);
        Task<IrAttachment> InitAsync(Guid[] ids);
        Task<IrAttachment> PreviewAttachmentAsync(Guid[] ids);
        Task<IrAttachment> RegenerateAssetsBundlesAsync(Guid[] ids);
        Task<IrAttachment> RegisterAsMainAttachmentAsync(IrAttachmentRegisterAsMainAttachmentRequestDto input);
    }
}