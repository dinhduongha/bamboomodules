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
    [Module("PhoneValidation", Category = "Misc", Depends = new[] { "base", "mail" })]
    public partial class PhoneBlacklistAppService : GenericAppService<PhoneBlacklist>, IPhoneBlacklistAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public PhoneBlacklistAppService(IRepository<PhoneBlacklist, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<PhoneBlacklist> AddAsync(PhoneBlacklistAddRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def add(self, number, message=None):
            // sanitized = self.env.user._phone_format(number=number)
            // return self._add([sanitized], message=message)
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PhoneBlacklist> AddAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def action_add(self):
            // self.add(self.number)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<PhoneBlacklist> AddInternalAsync(object numbers, object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def _add(self, numbers, message=None):
            // """ Add or re activate a phone blacklist entry.
            // 
            // :param numbers: list of sanitized numbers """
            // 
            // # Log on existing records
            // existing = self.env["phone.blacklist"].with_context(active_test=False).search([('number', 'in', numbers)])
            // if existing and message:
            //     existing._track_set_log_message(message)
            // 
            // records = self.create([{'number': n} for n in numbers])
            // 
            // # Post message on new records
            // new = records - existing
            // if new and message:
            //     for record in new:
            //         record.with_context(mail_post_autofollow_author_skip=True).message_post(
            //             body=message,
            //             subtype_xmlid='mail.mt_note',
            //         )
            // return records
            */
            return default;
        }

        public async Task<PhoneBlacklist> PhoneBlacklistRemoveAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def phone_action_blacklist_remove(self):
            // return {
            //     'name': _('Are you sure you want to unblacklist this phone number?'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'phone.blacklist.remove',
            //     'target': 'new',
            //     'context': {'dialog_size': 'medium'},
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PhoneBlacklist> RemoveAsync(PhoneBlacklistRemoveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def remove(self, number, message=None):
            // sanitized = self.env.user._phone_format(number=number)
            // return self._remove([sanitized], message=message)
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<PhoneBlacklist> RemoveInternalAsync(object numbers, object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def _remove(self, numbers, message=None):
            // """ Add de-activated or de-activate a phone blacklist entry.
            // 
            // :param numbers: list of sanitized numbers """
            // records = self.env["phone.blacklist"].with_context(active_test=False).search([('number', 'in', numbers)])
            // todo = [n for n in numbers if n not in records.mapped('number')]
            // if records:
            //     if message:
            //         records._track_set_log_message(message)
            //     records.action_archive()
            // if todo:
            //     new_records = self.create([{'number': n, 'active': False} for n in todo])
            //     if message:
            //         for record in new_records:
            //             record.with_context(mail_post_autofollow_author_skip=True).message_post(
            //                 body=message,
            //                 subtype_xmlid='mail.mt_note',
            //             )
            //     records += new_records
            // return records
            */
            return default;
        }

        protected async Task<PhoneBlacklist> SearchNumberInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py) ---
            // def _search_number(self, operator, value):
            // sanitize = self.env.user._phone_format
            // if operator in ('in', 'not in'):
            //     value = [sanitize(number=number) or number for number in value]
            // else:
            //     value = sanitize(number=value) or value
            // return [('number', operator, value)]
            */
            return default;
        }
    }
}