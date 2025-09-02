using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailMessageTranslationAppService : GenericApplicationService<MailMessageTranslation>, IMailMessageTranslationAppService
    {

        public MailMessageTranslationAppService(IRepository<MailMessageTranslation, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailMessageTranslation> GcTranslationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_translation.py) ---
            // def _gc_translations(self):
            // treshold = fields.Datetime().now() - relativedelta(weeks=2)
            // self.search([("create_date", "<", treshold)]).unlink()
            */
            return default;
        }

        public async Task<MailMessageTranslation> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_translation.py) ---
            // def init(self):
            // self.env.cr.execute(
            //     f"CREATE UNIQUE INDEX IF NOT EXISTS mail_message_translation_unique ON {self._table} (message_id, target_lang)"
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}