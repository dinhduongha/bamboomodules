using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class MailNotificationAppService : GenericAppService<MailNotification>, IMailNotificationAppService
    {

        public MailNotificationAppService(IRepository<MailNotification, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: mail_notification.py, METHOD: fields_get) ---
            */
            return await base.FieldsGetAsync(input);
        }

        public async Task<MailNotification> FormatFailureReasonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_notification.py, METHOD: format_failure_reason) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}