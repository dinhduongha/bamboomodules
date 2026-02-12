using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class MailMessageSubtypeAppService
    {

        protected async Task<MailMessageSubtype> DefaultSubtypesInternalAsync(object model_name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py, METHOD: _default_subtypes) ---
            */
            return default;
        }

        protected async Task<MailMessageSubtype> GetAutoSubscriptionSubtypesInternalAsync(object model_name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message_subtype.py, METHOD: _get_auto_subscription_subtypes) ---
            */
            return default;
        }

        protected async Task<MailMessageSubtype> GetDepartmentSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py, METHOD: _get_department_subtype) ---
            */
            return default;
        }

        protected async Task<MailMessageSubtype> UpdateDepartmentSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: mail_message_subtype.py, METHOD: _update_department_subtype) ---
            */
            return default;
        }
    }
}