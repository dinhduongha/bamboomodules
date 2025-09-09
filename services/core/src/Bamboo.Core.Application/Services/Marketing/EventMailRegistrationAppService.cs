using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("Event", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public class EventMailRegistrationAppService : GenericApplicationService<EventMailRegistration>, IEventMailRegistrationAppService
    {

        public EventMailRegistrationAppService(IRepository<EventMailRegistration, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<EventMailRegistration> ComputeScheduledDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py) ---
            // def _compute_scheduled_date(self):
            // for mail in self:
            //     if mail.registration_id:
            //         mail.scheduled_date = mail.registration_id.create_date.replace(microsecond=0) + _INTERVALS[mail.scheduler_id.interval_unit](mail.scheduler_id.interval_nbr)
            //     else:
            //         mail.scheduled_date = False
            */
            return default;
        }

        public async Task<EventMailRegistration> ExecuteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py) ---
            // def execute(self):
            // # Deprecated, to be called only from parent scheduler
            // skip_domain = self._get_skip_domain() + [("registration_id.state", "in", ("open", "done"))]
            // self.filtered_domain(skip_domain)._execute_on_registrations()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventMailRegistration> ExecuteOnRegistrationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py) ---
            // def _execute_on_registrations(self):
            // """ Private mail registration execution. We consider input is already
            // filtered at this point, allowing to let caller do optimizations when
            // managing batches of registrations. """
            // todo = self.filtered(
            //     lambda r: r.scheduler_id.notification_type == "mail"
            // )
            // for scheduler, reg_mails in todo.grouped('scheduler_id').items():
            //     scheduler._send_mail(reg_mails.registration_id)
            // todo.mail_sent = True
            // return todo
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: event_mail_registration.py) ---
            // def _execute_on_registrations(self):
            // todo = self.filtered(
            //     lambda r: r.scheduler_id.notification_type == "sms"
            // )
            // for scheduler, reg_mails in todo.grouped('scheduler_id').items():
            //     scheduler._send_sms(reg_mails.registration_id)
            // todo.mail_sent = True
            // 
            // return super(EventMailRegistration, self - todo)._execute_on_registrations()
            */
            return default;
        }

        protected async Task<EventMailRegistration> GetSkipDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail_registration.py) ---
            // def _get_skip_domain(self):
            // """ Domain of mail registrations ot skip: not already done, linked to
            // a valid registration, and scheduled in the past. """
            // return [
            //     ("mail_sent", "=", False),
            //     ("scheduled_date", "!=", False),
            //     ("scheduled_date", "<=", self.env.cr.now()),
            // ]
            */
            return default;
        }
    }
}