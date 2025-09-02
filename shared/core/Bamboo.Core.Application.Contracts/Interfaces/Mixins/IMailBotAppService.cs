using Volo.Abp.Application.Services;
using System.Linq;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using System;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IMailBotAppService : IMixinAppService
    {
        Task<TEntity> ApplyLogicInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object values, object command) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> BodyContainsEmojiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> GetAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object body, object values, object command) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> IsBotInPrivateChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> IsBotPingedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> IsHelpRequestedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailBotable;
    }
}