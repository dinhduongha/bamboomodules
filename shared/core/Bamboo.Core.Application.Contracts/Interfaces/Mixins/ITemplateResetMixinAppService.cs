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
    public interface ITemplateResetMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionCreateSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> ActionUnlinkSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> CancelUnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> CheckAbstractModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> ComputeCanWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> ComputeIsTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> ComputeTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> GenerateTemplateAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> GenerateTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object find_or_create_partners) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> GenerateTemplateRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object find_or_create_partners, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> GenerateTemplateScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> GenerateTemplateStaticValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> LoadRecordsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> OpenDeleteConfirmationModalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> OverrideTranslationTermInternalAsync<TEntity>(IEnumerable<TEntity> entities, object module_name, List<Guid> xml_ids) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> ResetTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> SearchTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> SendCheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> SendMailAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> SendMailBatchAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ITemplateResetMixinable;
    }
}