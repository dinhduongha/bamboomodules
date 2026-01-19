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
    [Module("MassMailing", Category = "Marketing", Depends = new[] { "contacts", "mail", "html_builder", "utm", "link_tracker", "social_media", "web_tour", "digest" })]
    public partial class MailingSubscriptionAppService : GenericApplicationService<MailingSubscription>, IMailingSubscriptionAppService
    {

        public MailingSubscriptionAppService(IRepository<MailingSubscription, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailingSubscription> ComputeOptOutDatetimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_subscription.py) ---
            // def _compute_opt_out_datetime(self):
            // self.filtered(lambda sub: not sub.opt_out).opt_out_datetime = False
            // for subscription in self.filtered('opt_out'):
            //     subscription.opt_out_datetime = self.env.cr.now()
            */
            return default;
        }

        public async Task<MailingSubscription> OpenMailingContactAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_subscription.py) ---
            // def open_mailing_contact(self):
            // action = {
            //     'name': _('Mailing Contacts'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'domain': [('id', 'in', self.contact_id.ids)],
            //     'res_model': 'mailing.contact',
            // }
            // if len(self) == 1:
            //     action.update({
            //         'name': _('Mailing Contact'),
            //         'view_mode': 'form',
            //         'res_id': self.contact_id.id,
            //     })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}