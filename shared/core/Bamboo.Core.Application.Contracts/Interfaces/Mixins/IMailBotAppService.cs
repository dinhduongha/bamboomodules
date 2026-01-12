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
    public interface IMailBotAppService : IMixinAppService
    {
        Task<TEntity> ApplyLogicInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object values, object command) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> BodyContainsEmojiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> GetAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object body, object values, object command) where TEntity : IEntity<Guid>, IMailBotable;
        Task<TEntity> IsHelpRequestedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailBotable;
    }
}