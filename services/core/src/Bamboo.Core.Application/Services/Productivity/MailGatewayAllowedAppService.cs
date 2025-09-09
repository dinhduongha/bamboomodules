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

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailGatewayAllowedAppService : GenericApplicationService<MailGatewayAllowed>, IMailGatewayAllowedAppService
    {

        public MailGatewayAllowedAppService(IRepository<MailGatewayAllowed, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailGatewayAllowed> ComputeEmailNormalizedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_gateway_allowed.py) ---
            // def _compute_email_normalized(self):
            // for record in self:
            //     record.email_normalized = tools.email_normalize(record.email)
            */
            return default;
        }

        public async Task<MailGatewayAllowed> GetEmptyListHelpAsync(Guid id, MailGatewayAllowedGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_gateway_allowed.py) ---
            // def get_empty_list_help(self, help_message):
            // get_param = self.env['ir.config_parameter'].sudo().get_param
            // LOOP_MINUTES = int(get_param('mail.gateway.loop.minutes', 120))
            // LOOP_THRESHOLD = int(get_param('mail.gateway.loop.threshold', 20))
            // 
            // return Markup(_('''
            //     <p class="o_view_nocontent_smiling_face">
            //         Add addresses to the Allowed List
            //     </p><p>
            //         To protect you from spam and reply loops, Odoo automatically blocks emails
            //         coming to your gateway past a threshold of <b>%(threshold)i</b> emails every <b>%(minutes)i</b>
            //         minutes. If there are some addresses from which you need to receive very frequent
            //         updates, you can however add them below and Odoo will let them go through.
            //     </p>''')) % {
            //     'threshold': LOOP_THRESHOLD,
            //     'minutes': LOOP_MINUTES,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}