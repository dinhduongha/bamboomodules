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
    public interface IDigestDigestAppService : IGenericApplicationService<DigestDigest>
    {
        Task<DigestDigest> ActivateAsync(Guid[] ids);
        Task<DigestDigest> DeactivateAsync(Guid[] ids);
        Task<DigestDigest> SendAsync(Guid[] ids);
        Task<DigestDigest> SendManualAsync(Guid[] ids);
        Task<DigestDigest> SetPeriodicityAsync(DigestDigestSetPeriodicityRequestDto input);
        Task<DigestDigest> SubscribeAsync(Guid[] ids);
        Task<DigestDigest> UnsubscribeAsync(Guid[] ids);
    }
}