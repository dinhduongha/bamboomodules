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
        Task<DigestDigest> ActivateAsync(Guid id);
        Task<DigestDigest> DeactivateAsync(Guid id);
        Task<DigestDigest> SendAsync(Guid id);
        Task<DigestDigest> SendManualAsync(Guid id);
        Task<DigestDigest> SetPeriodicityAsync(Guid id, DigestDigestSetPeriodicityRequestDto input);
        Task<DigestDigest> SubscribeAsync(Guid id);
        Task<DigestDigest> UnsubscribeAsync(Guid id);
    }
}