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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailMessageReactionAppService : GenericApplicationService<MailMessageReaction>, IMailMessageReactionAppService
    {

        public MailMessageReactionAppService(IRepository<MailMessageReaction, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<MailMessageReaction> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_reaction.py) ---
            // def init(self):
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS mail_message_reaction_partner_unique ON %s (message_id, content, partner_id) WHERE partner_id IS NOT NULL" % self._table)
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS mail_message_reaction_guest_unique ON %s (message_id, content, guest_id) WHERE guest_id IS NOT NULL" % self._table)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessageReaction> ToStoreInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message_reaction.py) ---
            // def _to_store(self, store: Store):
            // for (message_id, content), reactions in groupby(self, lambda r: (r.message_id, r.content)):
            //     reactions = self.env["mail.message.reaction"].union(*reactions)
            //     store.add(reactions.guest_id, fields=["avatar_128", "name"])
            //     store.add(reactions.partner_id, fields=["avatar_128", "name"])
            //     data = {
            //         "content": content,
            //         "count": len(reactions),
            //         "sequence": min(reactions.ids),
            //         "personas": Store.many_ids(reactions.guest_id)
            //         + Store.many_ids(reactions.partner_id),
            //         "message": Store.one_id(message_id),
            //     }
            //     store.add("MessageReactions", data)
            */
            return default;
        }
    }
}