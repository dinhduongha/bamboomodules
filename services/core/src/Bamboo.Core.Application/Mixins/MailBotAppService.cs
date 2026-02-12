using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail_bot", Category = "Productivity", Depends = new[] { "mail" })]
    public partial class MailBotAppService : ApplicationService, IMailBotAppService
    {

        public MailBotAppService() 
        {

        }

        public async Task<TEntity> ApplyLogicInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object values, object command) where TEntity : IEntity<Guid>, IMailBotable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: mail_bot.py, METHOD: _apply_logic) ---
            */
            return default;
        }

        public async Task<TEntity> BodyContainsEmojiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailBotable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: mail_bot.py, METHOD: _body_contains_emoji) ---
            */
            return default;
        }

        public async Task<TEntity> GetAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object body, object values, object command) where TEntity : IEntity<Guid>, IMailBotable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: mail_bot.py, METHOD: _get_answer) ---
            */
            return default;
        }

        protected async Task<object> GetStyleDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: mail_bot.py, METHOD: _get_style_dict) ---
            */
            return default;
        }

        public async Task<TEntity> IsHelpRequestedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailBotable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_bot, FILE: mail_bot.py, METHOD: _is_help_requested) ---
            */
            return default;
        }
    }
}