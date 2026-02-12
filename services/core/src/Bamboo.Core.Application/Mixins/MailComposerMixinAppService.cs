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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailComposerMixinAppService : ApplicationService, IMailComposerMixinAppService
    {

        public MailComposerMixinAppService() 
        {

        }

        public async Task<TEntity> ComputeBodyHasTemplateValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_body_has_template_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_body) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanEditBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_can_edit_body) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMailTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_is_mail_template_editor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_subject) ---
            */
            return default;
        }

        public async Task<TEntity> RenderFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _render_field) ---
            */
            return default;
        }

        public async Task<TEntity> RenderLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object engine) where TEntity : IEntity<Guid>, IMailComposerMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _render_lang) ---
            */
            return default;
        }
    }
}