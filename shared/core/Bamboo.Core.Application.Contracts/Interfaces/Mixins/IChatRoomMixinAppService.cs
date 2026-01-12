using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IChatRoomMixinAppService : IMixinAppService
    {
        Task<TEntity> ArchiveMeetingRoomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeCountryFlagUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeImage512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeIsInOpeningHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeWebsiteImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> DefaultSponsorTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> JitsiSanitizeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> OnchangeExhibitorTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> SynchronizeWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IChatRoomMixinable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IChatRoomMixinable;
    }
}