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
    public interface IIrAttachmentAppService : IGenericApplicationService<IrAttachment>
    {
        Task<IrAttachment> CheckAsync(Guid id, IrAttachmentCheckRequestDto input);
        Task<IrAttachment> CopyDataAsync(Guid id, IrAttachmentCopyDataRequestDto input);
        Task<IrAttachment> CreateUniqueAsync(Guid id, IrAttachmentCreateUniqueRequestDto input);
        Task<IrAttachment> ForceStorageAsync(Guid id);
        Task<IrAttachment> GenerateAccessTokenAsync(Guid id);
        Task<IrAttachment> GetAsync(Guid id);
        Task<IrAttachment> GetServingGroupsAsync(Guid id);
        Task<IrAttachment> RegenerateAssetsBundlesAsync(Guid id);
        Task<IrAttachment> RegisterAsMainAttachmentAsync(Guid id, IrAttachmentRegisterAsMainAttachmentRequestDto input);
        Task<IrAttachment> ValidateAccessAsync(Guid id, IrAttachmentValidateAccessRequestDto input);
    }
}