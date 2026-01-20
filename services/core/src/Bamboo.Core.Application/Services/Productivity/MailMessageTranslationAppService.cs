using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailMessageTranslationAppService : GenericApplicationService<MailMessageTranslation>, IMailMessageTranslationAppService
    {

        public MailMessageTranslationAppService(IRepository<MailMessageTranslation, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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