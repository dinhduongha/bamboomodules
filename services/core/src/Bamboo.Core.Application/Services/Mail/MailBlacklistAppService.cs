using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
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
    public class MailBlacklistAppService : GenericApplicationService<MailBlacklist>, IMailBlacklistAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public MailBlacklistAppService(IRepository<MailBlacklist, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<MailBlacklist> AddAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py) ---
            // def action_add(self):
            // self._add(self.email)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailBlacklist> AddInternalAsync(object email, object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py) ---
            // def _add(self, email, message=None):
            // normalized = tools.email_normalize(email)
            // record = self.env["mail.blacklist"].with_context(active_test=False).search([('email', '=', normalized)])
            // if len(record) > 0:
            //     if message:
            //         record._track_set_log_message(message)
            //     record.action_unarchive()
            // else:
            //     record = self.create({'email': email})
            //     if message:
            //         record.with_context(mail_create_nosubscribe=True).message_post(
            //             body=message,
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return record
            */
            return default;
        }

        public async Task<MailBlacklist> MailBlacklistRemoveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py) ---
            // def mail_action_blacklist_remove(self):
            // return {
            //     'name': _('Are you sure you want to unblacklist this email address?'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'mail.blacklist.remove',
            //     'target': 'new',
            //     'context': {'dialog_size': 'medium'},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailBlacklist> RemoveInternalAsync(object email, object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py) ---
            // def _remove(self, email, message=None):
            // normalized = tools.email_normalize(email)
            // record = self.env["mail.blacklist"].with_context(active_test=False).search([('email', '=', normalized)])
            // if len(record) > 0:
            //     if message:
            //         record._track_set_log_message(message)
            //     record.action_archive()
            // else:
            //     record = record.create({'email': email, 'active': False})
            //     if message:
            //         record.with_context(mail_create_nosubscribe=True).message_post(
            //             body=message,
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return record
            */
            return default;
        }

        protected async Task<MailBlacklist> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """ Override _search in order to grep search on email field and make it
            // lower-case and sanitized """
            // def normalize(arg):
            //     if isinstance(arg, (list, tuple)) and arg[0] == 'email' and isinstance(arg[2], str):
            //         normalized = tools.email_normalize(arg[2])
            //         if normalized:
            //             return (arg[0], arg[1], normalized)
            //     return arg
            // 
            // domain = [normalize(item) for item in domain]
            // return super()._search(domain, offset, limit, order)
            */
            return default;
        }

        protected async Task<MailBlacklist> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mail_blacklist.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'opt_out_reason_id' in init_values and self.opt_out_reason_id:
            //     return self.env.ref('mail.mt_comment')
            // return super()._track_subtype(init_values)
            */
            return default;
        }
    }
}