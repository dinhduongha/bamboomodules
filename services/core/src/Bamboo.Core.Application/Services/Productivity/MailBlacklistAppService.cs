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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailBlacklistAppService : GenericApplicationService<MailBlacklist>, IMailBlacklistAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public MailBlacklistAppService(IRepository<MailBlacklist, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
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
            //         record.with_context(mail_post_autofollow_author_skip=True).message_post(
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
            //         record.with_context(mail_post_autofollow_author_skip=True).message_post(
            //             body=message,
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return record
            */
            return default;
        }

        protected async Task<MailBlacklist> SearchInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py) ---
            // def _search(self, domain, *args, **kwargs):
            // """ Override _search in order to grep search on email field and make it
            // lower-case and sanitized """
            // domain = Domain(domain).map_conditions(
            //     lambda cond: Domain(cond.field_expr, cond.operator, norm_value)
            //     if cond.field_expr == 'email'
            //     and isinstance(cond.value, str)
            //     and (norm_value := tools.email_normalize(cond.value))
            //     else cond
            // )
            // return super()._search(domain, *args, **kwargs)
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