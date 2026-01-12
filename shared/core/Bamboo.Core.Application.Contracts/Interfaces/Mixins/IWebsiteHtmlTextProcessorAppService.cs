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
    public interface IWebsiteHtmlTextProcessorAppService : IMixinAppService
    {
        Task<TEntity> CalculateTranslationRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities, object generated_content, object translated_content) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> ComputePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_string) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> FormatReplacementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_string, object generated_content) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> GetProcessingCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cache_key) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> GetRenderedSnippetsContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object snippets) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> GetSnippetContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object snippet_key) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> ProcessSnippetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object snippet, object snippet_en) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> RenderSnippetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object snippet_key) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> UpdateProcessingCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cache_key, object updates) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> UpdateSnippetContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object generated_content, object snippet_key, object snippet_html) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
        Task<TEntity> WithProcessingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object IrQweb, object cta_data, object text_generation_target_lang, object text_must_be_translated_for_openai) where TEntity : IEntity<Guid>, IWebsiteHtmlTextProcessorable;
    }
}